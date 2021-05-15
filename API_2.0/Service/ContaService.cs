using API_2._0.Interfaces.Repository;
using API_2._0.Interfaces.Service;
using API_2._0.Models;
using API_2._0.Models.ModelsPost;
using API_2._0.Validation.BusinessValidation;
using API_2._0.Validation.ModelValidators;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace API_2._0.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;
        public ContaService(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
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

            var conta = _mapper.Map<ContaModel>(contaRequest);
            var response = new ContaValidaton().Validate(conta);
            if (!response.IsValid)
            {
                var errors = response.Errors.Select(a => a.ErrorMessage).ToList();
                return errors;
            }
            var responseBusiness = new ContaBusinessValidation(_contaRepository).Validate(conta);
            if (!responseBusiness.IsValid)
            {
                var errors = responseBusiness.Errors.Select(a => a.ErrorMessage).ToList();
                return errors;
            }
            return _contaRepository.Insert(conta);            
        }

        public object Update(ContaModel conta)
        {
            // busca no banco de dados a entidade atrelada do código
            var contatoDb = _contaRepository.GetOne(conta.Id_Conta);
            if (contatoDb == null)
            {
                return new List<string>() { "o id do contato não existe no banco de dados" };
            }
            var response = new ContaValidaton().Validate(conta);
            if (!response.IsValid)
            {
                var errors = response.Errors.Select(a => a.ErrorMessage).ToList();
                return errors;
            }
            var responseBusiness = new ContaBusinessValidation(_contaRepository).Validate(conta);
            if (!responseBusiness.IsValid)
            {
                var errors = responseBusiness.Errors.Select(a => a.ErrorMessage).ToList();
                return errors;
            }

            contatoDb.Email = conta.Email;
            contatoDb.NomeDoCredor = conta.NomeDoCredor;
            contatoDb.DataDoPagamento = conta.DataDoPagamento;


            return _contaRepository.Update(conta);
        }
    }
}
