using API_2._0.Models;
using API_2._0.Models.ModelsPost;
using AutoMapper;

namespace API_2._0.Mappers
{
    public class ModelMappers : Profile
    {
        public ModelMappers()
        {
            CreateMap<ContaModel, ContaModelRequest>();
            CreateMap<ContaModelRequest, ContaModel >();
        }
    }
}
