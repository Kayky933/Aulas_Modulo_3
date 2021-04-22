using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapperMVC.Models;
using AutoMapperMVC.ViewModels;

namespace AutoMapperMVC.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        public UsuarioModel GetDetails(int? id);
        public UsuarioModel GetEdit(int? id);
        public UsuarioModel GetCreate();
        public UsuarioModel GetOne(int id);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByName(string name);

        public UsuarioViewModel Postusuario(UsuarioViewModel usuario);
        public UsuarioViewModel PutUsuario(int id, UsuarioViewModel usuario);
        public bool Delete(UsuarioModel usuario);
    }
}
