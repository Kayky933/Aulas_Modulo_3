using API_2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2._0.Context
{
    public class API2_Context : DbContext
    {

        public API2_Context(DbContextOptions<API2_Context> options)
            : base(options)
        {
        }

        public DbSet<ContaModel> Conta { get; set; }

    }
}
