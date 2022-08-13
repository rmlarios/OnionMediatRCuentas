using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationC.Features.ClienteFeatures.Queries.GetAllClients;
using ApplicationC.Features.CuentaFeatures.Commands;
using ApplicationC.Features.CuentaFeatures.Commands.CreateCuenta;
using ApplicationC.Features.CuentaFeatures.Commands.DeleteCuenta;
using ApplicationC.Features.CuentaFeatures.Commands.UpdateCuenta;
using ApplicationC.Features.CuentaFeatures.Queries.GetAllCuentas;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CuentasController: BaseController
    {
        /// <summary>
        /// Obtener todos los registros de Cuentas paginados según criterios de búsqueda
        /// </summary>
        /// <param name="specification">Criterios de búsqueda</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCuentasSpecification specification)
        {
            return Ok(await MediatR.Send(new GetAllCuentasQuery()
            {
                PageSize = specification.PageSize, 
                PageNumber = specification.PageNumber,
                FilterEstado = specification.FilterEstado,
                FilterIdCliente = specification.FilterIdCliente
            }));
        }
        /// <summary>
        /// Crear un registro de cliente
        /// </summary>
        /// <param name="command">Propiedades del registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCuentaCommand command)
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
        public async Task<IActionResult> Put(int id, UpdateCuentaCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await MediatR.Send(command));
        }
        /// <summary>
        /// Eliminar un registro de Cuenta
        /// </summary>
        /// <param name="id">Id del Registro a Eliminar</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await MediatR.Send(new DeleteCuentaCommand() { Id = id }));
        }
    }
}
