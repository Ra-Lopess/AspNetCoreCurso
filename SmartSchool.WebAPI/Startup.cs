using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
            services.AddDbContext<DataContext>( // apresenta o contexto que sera responsavel por gerenciar a minha conex�o com o BD
                c => c.UseMySql(Configuration.GetConnectionString("MySqlConnection"),
                new MySqlServerVersion(new Version(8, 0, 26)))
            );

            // todas as vezes que eu estiver utilizando o IRepository, ele esteja inserindo o Repository (Independence injection)
            services.AddScoped<IRepository, Repository>();

            // outra maneira de fazer a inje��o de dependencia
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // fazer o mapeamento entre meu Dtos e meus Models, feito no meu helpers que ligam a partir do profile

            // esse AddNewtonsoftJson � pq tava dando problema de loop nos models, ja que varios se chamavam e entrava no loop
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

            // Versionamento da api
            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV"; // exista um grupo
                options.SubstituteApiVersionInUrl = true; // mudamos a url
            })
            .AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true; // vers�o padr�o pra api
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>(); // pega nossas versoes

            services.AddSwaggerGen(c =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions) { // para ter para todas as versoes

                    c.SwaggerDoc(description.GroupName, // nome da vers�o
                                 new OpenApiInfo { Title = "SmartSchool.WebAPI", 
                                                   Version = description.ApiVersion.ToString(), // mudar a vers�o a cada loop 
                                                   Description = "Descrição da Api" });

                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // adiciona os comentarios no Swagger
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile); // conecta nosso xml acima com o base
                    c.IncludeXmlComments(xmlCommentsFullPath);

                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              IApiVersionDescriptionProvider apiVersionDescription) // passa isso para o versionamento
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                foreach (var description in apiVersionDescription.ApiVersionDescriptions) {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    c.RoutePrefix = "";

                }
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
