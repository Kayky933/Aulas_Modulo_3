using API_2._0.Context;
using API_2._0.Interfaces.Repository;
using API_2._0.Models;
using API_2._0.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly API2_Context _context;
        public ContaRepository(API2_Context context)
        {
            _context = context;
        }

        public bool Delete(ContaModel conta)
        {
            try
            {
                _context.Remove(conta);
                _context.SaveChanges();
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
            return _context.Conta.Where(e => e.Email == email).LastOrDefault();
        }       

        public IEnumerable<ContaModel> GetByName(string name)
        {
            return _context.Conta.Where(e => e.NomeDoCredor == name);
        }

        public ContaModel GetOne(int id)
        {
            return _context.Conta.Where(e => e.Id_Conta == id).FirstOrDefault();
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
                return this.GetOne(conta.Id_Conta);
            }
            catch (DbUpdateConcurrencyException)
            {

                return null;
            }
        }
    }
}
