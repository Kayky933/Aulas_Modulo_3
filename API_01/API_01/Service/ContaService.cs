using API_01.Data;
using API_01.Interfaces.Repository;
using API_01.Interfaces.Service;
using API_01.Models;
using API_01.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Service
{
    public class ContaService : IContaService
    {
        private readonly ContaRepository _contaRepository;

        public ContaService(ContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public bool Delete(int id)
        {
            var obj =this.GetOne(id);
            if (obj == null)
                return false;
            return _contaRepository.Delete(obj);
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
            if (conta.NomeDoCredor == "")
                return null;

            return _contaRepository.Insert(conta);
        }

        public ContaModel Update(ContaModel conta)
        {
            return _contaRepository.Update(conta);
        }
    }
}
