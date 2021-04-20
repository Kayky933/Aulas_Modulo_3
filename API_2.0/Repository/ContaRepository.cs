using API_2._0.Data;
using API_2._0.Interfaces.Repository;
using API_2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly APIContext _context;
        public ContaRepository(APIContext context)
        {
            _context = context;
        }
        public bool ContactEmailExist(int codigo, string email)
        {
            var item = _context.Conta.Where(a => a.Email == email && a.Id_Conta == codigo).ToList();
            return item.Any();
        }

        public bool ContactNameExist(int codigo, string name)
        {
            var item = _context.Conta.Where(a => a.NomeDoCredor == name && a.Id_Conta != codigo).ToList();
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
            return _context.Conta.Where(a => a.Email == email).FirstOrDefault();
        }

        public IEnumerable<ContaModel> GetByName(string name)
        {
            return _context.Conta.Where(a => a.NomeDoCredor == name);
        }

        public ContaModel GetOne(int id)
        {
            return _context.Conta.Where(a => a.Id_Conta == id).FirstOrDefault();
        }

        public ContaModel Insert(ContaModel conta)
        {
            try
            {
                _context.Add(conta);
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
                return this.GetOne(conta.Id_Conta);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
