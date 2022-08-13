using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Specifications;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos
{
    public class GetAllMovimientosSpecification:RequestSpecification
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
