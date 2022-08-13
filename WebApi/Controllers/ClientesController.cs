using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationC.Features.ClienteFeatures.Commands.CreateCliente;
using ApplicationC.Features.ClienteFeatures.Commands.DeleteCliente;
using ApplicationC.Features.ClienteFeatures.Commands.UpdateCliente;
using ApplicationC.Features.ClienteFeatures.Queries;
using ApplicationC.Features.ClienteFeatures.Queries.GetAllClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ClientesController: BaseController
    {

        /// <summary>
        /// Obtener todos los registros de Cuentas paginados
        /// </summary>
        /// <param name="specification">Criterios de paginación</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllClientesSpecification specification)
        {
            return Ok(await MediatR.Send(new GetAllClientesQuery(){PageSize = specification.PageSize, PageNumber = specification.PageNumber}));
        }
        /// <summary>
        /// Crear un registro de cliente
        /// </summary>
        /// <param name="command">Propiedades del registro a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await MediatR.Send(command));
        }
        /// <summary>
        /// Actualizar un registro de Cliente
        /// </summary>
        /// <param name="id">Id del Registro a Editar</param>
        /// <param name="command">Propiedades a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await MediatR.Send(command));
        }

        /// <summary>
        /// Eliminar un registro de Cliente
        /// </summary>
        /// <param name="id">Id del Registro a Eliminar</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await MediatR.Send(new DeleteClienteCommand {Id = id}));
        }
    }
}
