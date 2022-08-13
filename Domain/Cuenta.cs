using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain
{
    public class Cuenta: Base
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }
        [Required("")]
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public virtual Cliente Cliente { get; }
        public virtual ICollection<Movimiento> Movimientos { get;}
    }
}
