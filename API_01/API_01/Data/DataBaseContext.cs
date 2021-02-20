using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_01.Models;
using Microsoft.EntityFrameworkCore;

namespace API_01.Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<ContaModel> Conta { get; set; }
        
    }

}