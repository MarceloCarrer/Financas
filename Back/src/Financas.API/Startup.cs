using Financas.Application;
using Financas.Application.Contracts;
using Financas.Persistence;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Financas.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System;

namespace Financas.API
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

            services.AddDbContext<DataContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaPersistence, CategoriaPersistence>();
            services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();
            services.AddScoped<IFormaPagamentoPersistence, FormaPagamentoPersistence>();
            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IEstabelecimentoPersistence, EstabelecimentoPersistence>();            
            services.AddScoped<IGastoService, GastoService>();
            services.AddScoped<IGastoPersistence, GastoPersistence>();
            services.AddScoped<IParceladoService, ParceladoService>();
            services.AddScoped<IParceladoPersistence, ParceladoPersistence>();
            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddScoped<IParcelaPersistence, ParcelaPersistence>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();


            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Financas.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Financas.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
                x => x.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
