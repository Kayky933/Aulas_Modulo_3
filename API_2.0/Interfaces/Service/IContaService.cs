using API_2._0.Models;
using API_2._0.Models.ModelsPost;
using System.Collections.Generic;

namespace API_2._0.Interfaces.Service
{
    public interface IContaService
    {
        IEnumerable<ContaModel> GetAll();
        ContaModel GetOne(int id);
        object Update(ContaModel conta);
        bool Delete(int id);
        object Insert(ContaModelRequest contaModel);
    }
}
