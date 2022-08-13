using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using ApplicationC.Interfaces;
using ApplicationC.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DBConnectionString"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            #region Repositories

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<IMovimientoRepository, MovimientoRepository>();
            #endregion
        }
    }
}
