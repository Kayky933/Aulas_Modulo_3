using API_2._0.Interfaces.Repository;
using API_2._0.Interfaces.Service;
using API_2._0.Mappers;
using API_2._0.Repository;
using API_2._0.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API_2._0.StartUpConfig
{
    public class StartUpConfiguration
    {
        public static void ConfigureDependencInjection(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaRepository, ContaRepository>();
        }
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Primeira api do curso Desenvolvimento Etec",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "kayky.santana@etec.sp.gov.br",
                            Name = "Kayky Matos",
                            Url = new Uri("http://www.etecitu.com.br")
                        },
                        Description = "Esta api é um teste"
                    });
            });
        }
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelMappers));
        }
    }
}
