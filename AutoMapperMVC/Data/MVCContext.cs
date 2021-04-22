using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapperMVC.Models;

namespace AutoMapperMVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<AutoMapperMVC.Models.UsuarioModel> UsuarioModel { get; set; }
        public DbSet<AutoMapperMVC.Models.EnderecoModel> UsuarioEndereco { get; set; }
    }
}
