using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Persona : Base
    {
        [Required]
        [StringLength(40)]
        public string  Nombre { get; set; }
        [Required]
        public string  Genero { get; set; }
        [Required]
        public int  Edad { get; set; }
        [Required]
        public string  Identificacion { get; set; }
        [Required]
        public string  Dirección { get; set; }
        [Required]
        public string  Telefono { get; set; }
    }
}
