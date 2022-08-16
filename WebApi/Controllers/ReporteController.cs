using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationC.Features.MovimientoFeatures.Queries.GetMovimientosPorCLienteFecha;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ReporteController: BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetMovimientosPorClienteFechaSpec specification)
        {
            return Ok(await MediatR.Send(new GetMovimientosPorClienteFechaQuery()
            {
                PageSize = specification.PageSize,
                PageNumber = specification.PageNumber,
                ClienteId = specification.ClienteId,
                FechaInicio = specification.FechaInicio,
                FechaFin = specification.FechaFin
            }));
        }
    }
}
