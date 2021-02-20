using API_01.Data;
using API_01.Interfaces.Repository;
using API_01.Interfaces.Service;
using API_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Service
{
    public class contaRepository : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public contaRepository(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public bool Delete(int id)
        {
            var obj = this.GetOne(id);
            if (obj == null)
                return false;

            return _contaRepository.Delete(id);
        }

        public IEnumerable<ContaModel> GetAll()
        {
            return _contaRepository.GetAll().OrderBy(a => a.NomeDoCredor);
        }

        public ContaModel GetOne(int id)
        {
            return _contaRepository.GetOne(id);
        }

        public ContaModel Insert(ContaModel conta)
        {
            try
            {
                if (conta.NomeDoCredor == "")
                    return null;
               return _contaRepository.Insert(conta);
            }
            catch (Exception)
            {
                return null;
            }           
        }

        public ContaModel Update(ContaModel conta)
        {
            return _contaRepository.Update(conta);
        }
    }
}
