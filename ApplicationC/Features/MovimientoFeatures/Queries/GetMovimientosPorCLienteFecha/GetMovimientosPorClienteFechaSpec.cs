using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Specifications;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetMovimientosPorCLienteFecha
{
    public class GetMovimientosPorClienteFechaSpec:RequestSpecification
    {
        public int ClienteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
