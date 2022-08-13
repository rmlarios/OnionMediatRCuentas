using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Persona : Base
    {
        public string  Nombre { get; set; }
        public string  Genero { get; set; }
        public int  Edad { get; set; }
        public string  Identificacion { get; set; }
        public string  Dirección { get; set; }
        public string  Telefono { get; set; }
    }
}
