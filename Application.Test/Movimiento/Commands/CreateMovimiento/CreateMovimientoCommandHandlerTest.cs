using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Test.TestUtils;
using ApplicationC.Features.MovimientoFeatures.Commands.CreateMovimiento;
using ApplicationC.Interfaces;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Parametrics;
using AutoMapper;
using Domain;
using ImpromptuInterface;
using Moq;
using Persistence.Repositories;
using Xunit;

namespace Application.Test.Movimiento.Commands.CreateMovimiento
{
    [Collection("CommonTestCollection")]
    public class CreateMovimientoCommandHandlerTest : BaseTest
    {
        [Fact]
        public async Task Handle_Ok()
        {
            //ARRANGE
            var request = new CreateMovimientoCommand
            {
                TipoMovimiento = Domain.Movimiento.CREDITO,
                Valor = 100,
                Fecha = DateTime.Now,
                CuentaId = 1
            };

            var cliente = new Cliente
            {
                Nombre = "Juan",
                Contraseña = "123",
                Dirección = "abc",
                Telefono = "888888",
                Edad = 25,
                Estado = true,
                Genero = "M"
            };

            var cuenta = new Cuenta
            {
                Id = 1,
                NumeroCuenta = "123456",
                TipoCuenta = TipoCuenta.AHORRO,
                Estado = true,
                SaldoInicial = 100,
                Cliente = cliente
            };

            await context.Clientes.AddAsync(cliente);
            await context.Cuentas.AddAsync(cuenta);
            await context.SaveChangesAsync();

            var _cuentaRepository = repositoryResolver.ResolveInMemoryMock<ICuentaRepository>();
            var _movimientoRepository = repositoryResolver.ResolveInMemoryMock<IMovimientoRepository>();
            var sut = new CreateMovimientoCommand.CreateMovimientoCommandHandler(_movimientoRepository, mapper,_cuentaRepository);

            //ACTUAL
            await sut.Handle(request, CancellationToken.None);
            
            //ASSERT
            Assert.NotEmpty(context.Movimientos);
            Assert.Equal(1,context.Movimientos.Count());
            Assert.Equal(request.Fecha.ToShortDateString(), context.Movimientos.First().Fecha.ToShortDateString());
        }
    }
}
