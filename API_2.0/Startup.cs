using API_2._0.Data;
using API_2._0.Interfaces.Repository;
using API_2._0.Interfaces.Service;
using API_2._0.Repository;
using API_2._0.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API_2._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddMvc()
            //   .AddFluentValidation(c =>
            //               c.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                config =>
                {
                    config.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                });
            });

            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaRepository, ContaRepository>();

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

            services.AddDbContext<APIContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("Connection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowAllOrigins");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Primeira Api ");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
