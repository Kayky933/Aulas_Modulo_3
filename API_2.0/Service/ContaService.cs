using API_2._0.ExtensionMethods;
using API_2._0.Interfaces.Repository;
using API_2._0.Interfaces.Service;
using API_2._0.Models;
using API_2._0.Models.ModelsPost;
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
            return _contaRepository.GetAll();
        }

        public ContaModel GetOne(int id)
        {
            return _contaRepository.GetOne(id);
        }

        public object Insert(ContaModelRequest contaModel)
        {
            var conta = ContaModelExtension.ToContaModel(contaModel);
            return _contaRepository.Insert(conta);
        }

        public object Update(ContaModel conta)
        {
            var contatoDb = _contaRepository.GetOne(conta.Id_Conta);
            if (contatoDb == null)
            {
                return new List<string>() { "o id do contato não existe no banco de dados" };
            }
            contatoDb.Email = conta.Email;
            contatoDb.NomeDoCredor = conta.NomeDoCredor;
            contatoDb.DataDoPagamento = conta.DataDoPagamento;

            return _contaRepository.Update(conta);
        }
    }
}
