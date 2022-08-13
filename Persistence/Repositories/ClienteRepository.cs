using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ClienteRepository: GenericRepository<Cliente>, IClienteRepository
    {
        private readonly DbSet<Cliente> _clientes;

        public ClienteRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _clientes = dbContext.Set<Cliente>();
        }
    }
}
