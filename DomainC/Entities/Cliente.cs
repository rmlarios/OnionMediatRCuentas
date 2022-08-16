using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public partial class Cliente : Persona
    {
        public Cliente()
        {
            Cuentas = new List<Cuenta>();
        }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
