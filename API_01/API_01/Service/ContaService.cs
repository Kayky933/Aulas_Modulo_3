using API_01.Contracts.Post;
using API_01.Data;
using API_01.ExtensionMethods;
using API_01.Interfaces.Repository;
using API_01.Interfaces.Service;
using API_01.Models;
using API_01.Repository;
using API_01.Validacao;
using API_01.Validators.BusinessValidator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Service
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
            return _contaRepository.GetAll().OrderBy(a => a.NomeDoCredor);
        }

        public ContaModel GetOne(int id)
        {
            return _contaRepository.GetOne(id);
        } 

        public object Insert(ContaModelRequest contaRequest)
        {

            var conta = contaRequest.ToContaModel();

            var validacao = new ContaModelValidator().Validate(conta);

            if (!validacao.IsValid)
            {
                var erros = validacao.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            var businessValidation = new ContaBusinessValidator(_contaRepository).Validate(conta);

            if (!businessValidation.IsValid)
            {
                var erros = businessValidation.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            return _contaRepository.Insert(conta);
        }

        public object Update(ContaModel conta)
        {
            var validacao = new ContaModelValidator().Validate(conta);

            if (!validacao.IsValid)
            {
                var erros = validacao.Errors.Select(a => a.ErrorMessage).ToList();
                return erros;
            }

            // busca no banco de dados a entidade atrelada do código
            var contatoDb = _contaRepository.GetOne(conta.Id);
            if (contatoDb == null)
            {
                return new List<string>() { "o id do contato não existe no banco de dados" };
            }

            // business validation

            contatoDb.Email = conta.Email;
            contatoDb.NomeDoCredor = conta.NomeDoCredor;
            contatoDb.DataDoPagamento = conta.DataDoPagamento;


            return _contaRepository.Update(conta);
        }
    }
}
