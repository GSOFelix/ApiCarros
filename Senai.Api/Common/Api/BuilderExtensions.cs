using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Senai.Api.Data;
using Senai.Api.Handlers;
using Senai.Core;
using Senai.Core.Handler;
using System.Reflection;

namespace Senai.Api.Common.Api
{
    public static class BuilderExtensions
    {
        //Contexto do banco de dados
        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>
                (x =>
                x.UseNpgsql(builder.Configuration.GetConnectionString("DefautConnection")));
        }

        //Servicos e dependencias
        public static void AddService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICarsHandler, CarsHandles>();
        }

        //Documentação da api
        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
        }
    }
}
