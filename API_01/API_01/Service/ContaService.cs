using API_01.Data;
using API_01.Interfaces.Service;
using API_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaService _contaService;

        public ContaService(IContaService contaService)
        {
            _contaService = contaService;
        }

        public bool Delete(int id)
        {
            var obj = this.GetOne(id);
            if (obj == null)
                return false;

            return _contaService.Delete(id);

        }

        public IEnumerable<ContaModel> GetAll()
        {
            return _contaService.GetAll().OrderBy(a => a.NomeDoCredor);
        }

        public ContaModel GetOne(int id)
        {
            return _contaService.GetOne(id);
        }

        public ContaModel Insert(ContaModel conta)
        {
            try
            {
                if (conta.NomeDoCredor == "")
                    return null;
                return _contaService.Insert(conta);
                
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ContaModel Update(ContaModel conta)
        {

            return _contaService.Update(conta);
        }
    }
}
