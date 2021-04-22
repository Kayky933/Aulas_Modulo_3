using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapperMVC.Models;
using AutoMapperMVC.ViewModels;

namespace AutoMapperMVC.AutoMapper
{
    public class AutoMapperTest : Profile
    {
        public AutoMapperTest()
        {
           CreateMap<UsuarioModel, UsuarioViewModel>();

            CreateMap<UsuarioViewModel, UsuarioModel>();
        }
    }
}
