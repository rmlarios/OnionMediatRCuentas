using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationC.Features.CuentaFeatures.Commands.UpdateCuenta;
using ApplicationC.Features.MovimientoFeatures.Commands.CreateMovimiento;
using ApplicationC.Features.MovimientoFeatures.Commands.DeleteMovimiento;
using ApplicationC.Features.MovimientoFeatures.Commands.UpdateMovimiento;
using ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MovimientosController : BaseController
    {
        /// <summary>
        /// Obtener todos los registros de Cuentas paginados según criterios de búsqueda
        /// </summary>
        /// <param name="specification">Criterios de búsqueda</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMovimientosSpecification specification)
        {
            return Ok(await MediatR.Send(new GetAllMovimientosQuery()
            {
                PageSize = specification.PageSize,
                PageNumber = specification.PageNumber
            }));
        }
        /// <summary>
        /// Crear un registro de cliente
        /// </summary>
        /// <param name="command">Propiedades del registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMovimientoCommand command)
        {
            return Ok(await MediatR.Send(command));
        }
        /// <summary>
        /// Actualizar un registro de Cuenta
        /// </summary>
        /// <param name="id">Id del Registro a Editar</param>
        /// <param name="command">Propiedades a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMovimientoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await MediatR.Send(command));
        }
        /// <summary>
        /// Eliminar un registro de Movimiento
        /// </summary>
        /// <param name="id">Id del Registro a Eliminar</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await MediatR.Send(new DeleteMovimientoCommand() { Id = id }));
        }
    }
}
