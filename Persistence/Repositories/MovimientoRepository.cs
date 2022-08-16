using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public abstract class MovimientoRepository: GenericRepository<Movimiento>, IMovimientoRepository
    {
        private readonly DbSet<Movimiento> _movimientos;

        public MovimientoRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _movimientos = dbContext.Set<Movimiento>();
        }
    }
}
