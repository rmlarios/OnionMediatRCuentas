using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ApplicationC.Interfaces.Repositories
{
    public interface ICuentaRepository:IGenericRepository<Cuenta>
    {
        Task<bool> EsNumeroCuentaUnicoAsync(string numeroCuenta, int idCuenta = 0);
    }
}
