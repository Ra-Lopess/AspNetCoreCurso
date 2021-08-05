using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } // podemos acessar nosso appsettings.json com isso

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>( // apresenta o contexto que sera responsavel por gerenciar a minha conexão com o BD
                context => context.UseSqlite(Configuration.GetConnectionString("Default")) // pega a string do configuration (appsettigns)
            );

            // todas as vezes que eu estiver utilizando o IRepository, ele esteja inserindo o Repository (Independence injection)
            services.AddScoped<IRepository, Repository>();

            // outra maneira de fazer a injeção de dependencia
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // fazer o mapeamento entre meu Dtos e meus Models, feito no meu helpers que ligam a partir do profile

            // esse AddNewtonsoftJson é pq tava dando problema de loop nos models, ja que varios se chamavam e entrava no loop
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartSchool.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSchool.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
