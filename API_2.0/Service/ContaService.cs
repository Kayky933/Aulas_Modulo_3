using API_2._0.ExtensionMethods;
using API_2._0.Interfaces.Repository;
using API_2._0.Interfaces.Service;
using API_2._0.Models;
using API_2._0.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public bool Delete(int id)
        {
            var obj = this.GetOne(id);
            if (obj == null)
                return false;
            return _contaRepository.Delete(obj);
        }

        public IEnumerable<ContaModel> GetAll()
        {
           return _contaRepository.GetAll().OrderBy(a => a.Id_Conta);
        }

        public ContaModel GetByEmail(string email)
        {
            return _contaRepository.GetByEmail(email);
        }

        public ContaModel GetOne(int id)
        {
            return _contaRepository.GetOne(id);
        }

        public object Insert(ContaModel contaModel)
        {
            return _contaRepository.Insert(contaModel);
        }

        public object Insert(ContaModelRequest contaModel)
        {
            var contaPost = ContaModelExtension.ToContaModel(contaModel);
            return _contaRepository.Insert(contaPost);
        }

        public object Update(ContaModel conta)
        {
            return _contaRepository.Update(conta);
        }
    }
}
