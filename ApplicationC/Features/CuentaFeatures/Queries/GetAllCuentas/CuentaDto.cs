using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Features.ClienteFeatures.Queries.GetAllClients;
using ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos;

namespace ApplicationC.Features.CuentaFeatures.Queries.GetAllCuentas
{
    public class CuentaDto
    {
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public virtual ClienteDto Cliente { get; set; }
        public virtual IEnumerable<MovimientoDto> Movimientos { get; set; }
    }
}
