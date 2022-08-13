using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos
{
    public class MovimientoDto
    {
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public bool Saldo { get; set; }
        public virtual Cuenta Cuenta { get; set; }
    }
}
