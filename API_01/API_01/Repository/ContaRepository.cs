using API_01.Data;
using API_01.Interfaces.Repository;
using API_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DataBaseContext _context;
 
        public ContaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public bool ContactEmailExist(int id, string email)
        {
            var item = _context.Conta.Where(a => a.Email == email && a.Id != id).ToList();
            return item.Any();
        }

        public bool ContactNameExist(int id, string name)
        {
            var item = _context.Conta.Where(a => a.NomeDoCredor == name && a.Id!= id).ToList();
            return item.Any();
        }

        public bool Delete(ContaModel conta)
        {
            try
            {
                _context.Conta.Remove(conta);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ContaModel> GetAll()
        {
            return _context.Conta.ToList();
        }

        public ContaModel GetByEmail(string email)
        {
            return _context.Conta.Where(a => a.Email == email).LastOrDefault();
        }

        public IEnumerable<ContaModel> GetByName(string name)
        {
            return _context.Conta.Where(n => n.NomeDoCredor == name);
        }

        public ContaModel GetOne(int id)
        {
            return _context.Conta.Find(id);
        }

        public ContaModel Insert(ContaModel conta)
        {
            try
            {
                _context.Conta.Add(conta);
                _context.SaveChanges();
                return conta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ContaModel Update(ContaModel conta)
        {
            try
            {
                _context.SaveChanges();
                return this.GetOne(conta.Id);
            }
            catch (DbUpdateConcurrencyException)
            {

                return null;
            }
        }
    }

}
