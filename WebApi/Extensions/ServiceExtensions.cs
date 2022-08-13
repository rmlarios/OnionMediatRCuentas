using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\DevSuAPI.xml");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DevSuAPI",
                    Description = "This Api will created for DevSu recruitment Test.",
                    Contact = new OpenApiContact
                    {
                        Name = "Miguel Larios",
                        Email = "mlariosc7@hotmail.com",
                        Url = new Uri("https://github.com/rmlarios"),
                    }
                });

            });
        }
    }
}
