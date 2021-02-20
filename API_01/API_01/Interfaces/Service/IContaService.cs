using API_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_01.Interfaces.Service
{
    public interface IContaService
    {
        IEnumerable<ContaModel> GetAll();
        ContaModel GetOne(int id);


        ContaModel Update(ContaModel conta);
        ContaModel Insert(ContaModel conta);

        bool Delete(int id);
    }
}
