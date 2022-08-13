using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movimiento: Base
    {
        public Movimiento()
        {
            
        }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public bool Saldo { get; set; }
        public virtual Cuenta Cuenta { get; }
    }
}
