using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cliente : Persona
    {
        public Cliente()
        {
            Cuentas = new List<Cuenta>();
        }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; private set; }
    }
}
