using API_2._0.Models;
using API_2._0.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Interfaces.Repository
{
    public interface IContaRepository
    {
        IEnumerable<ContaModel> GetAll();
        ContaModel GetOne(int id);
        ContaModel GetByEmail(string email);
        IEnumerable<ContaModel> GetByName(string name);
        ContaModel Update(ContaModel conta);
        bool Delete(ContaModel conta);
        ContaModel Insert(ContaModel conta);
    }
}
