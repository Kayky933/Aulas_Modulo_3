﻿using API_2._0.Models;
using API_2._0.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Interfaces.Service
{
    public interface IContaService
    {
        IEnumerable<ContaModel> GetAll();
        ContaModel GetOne(int id);
        ContaModel GetByEmail(string email);
        object Update(ContaModel conta);
        bool Delete(int id);
        object Insert(ContaModelRequest contaModel);
    }
}