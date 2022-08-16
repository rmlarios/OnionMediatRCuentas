using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetMovimientosPorCLienteFecha
{
    public class MovimientosPorClienteFechaDto
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
    }
}
