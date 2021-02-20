using API_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Interfaces.Repository
{
    public interface IContaRepository
    {
        IEnumerable<ContaModel> GetAll();

        ContaModel GetOne(int id);

        ContaModel Update(ContaModel conta);

        ContaModel Insert(ContaModel conta);

        bool Delete(ContaModel conta);

        IEnumerable<ContaModel> GetByName(string name);
    }
}
