using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CuentaRepository: GenericRepository<Cuenta>, ICuentaRepository
    {
        private readonly DbSet<Cuenta> _cuentas;

        public CuentaRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _cuentas = dbContext.Set<Cuenta>();
        }

        public Task<bool> EsNumeroCuentaUnicoAsync(string numeroCuenta, int idCuenta=0)
        {
            return _cuentas.Where(c=>c.Id!=idCuenta)
                .AllAsync(p => p.NumeroCuenta != numeroCuenta && p.Id!= idCuenta);
        }
    }
}
