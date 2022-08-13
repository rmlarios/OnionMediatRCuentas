using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationC.Features.ClienteFeatures.Queries.GetAllClients
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
    }
}
