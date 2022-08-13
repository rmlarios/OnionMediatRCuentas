using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Persona> Personas { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Cuenta> Cuentas { get; set; }
        DbSet<Movimiento> Movimientos { get; set; }
        Task<int> SaveChanges();
    }
}
