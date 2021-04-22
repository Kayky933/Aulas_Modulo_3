using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapperMVC.Models;
using AutoMapperMVC.ViewModels;

namespace AutoMapperMVC.Interfaces.Service
{
    public interface IUsuarioService
    {
        public UsuarioModel GetDetails(int? id);
        public UsuarioModel GetEdit(int? id);
        public UsuarioModel GetCreate();
        public UsuarioModel GetOne(int id);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByName(string name);

        public object Postusuario(UsuarioViewModel usuario);
        public object PutUsuario(int id, UsuarioViewModel usuario);
        public bool Delete(UsuarioModel usuario);
    }
}
