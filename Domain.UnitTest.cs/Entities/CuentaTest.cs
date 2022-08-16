using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.UnitTest.cs.Entities
{
    public class MovimientoTests
    {
        [Fact(DisplayName = "Cuando se han hecho debitos por 1000 ya no se puede hacer otro")]
        public void LimiteDiarioSuperado_True()
        {
            //ARRANGE
            var fechaActual = DateTime.Now;
            var cuenta = new Cuenta
            {
                Id = 1,
                Movimientos = new List<Movimiento>
                {
                    new Movimiento
                    {
                        Id = 1,
                        Fecha = fechaActual,
                        TipoMovimiento = Movimiento.DEBITO,
                        Valor = -1000
                    }
                }
            };

            //ACT
            var actual = cuenta.LimiteDiarioSuperado(fechaActual,-100);

            //ASSERT
            Assert.True(actual);
        }

        [Fact(DisplayName = "Cuando se quiere hacer débito y ya no tiene fondos suficientes ya no se puede registar")]
        public void TieneSaldoDisponible_False()
        {
            //ARRANGE
            var fechaActual = DateTime.Now;
            var cuenta = new Cuenta
            {
                Id = 1,
                SaldoInicial = 1000,
                Movimientos = new List<Movimiento>
                {
                    new Movimiento
                    {
                        Id = 1,
                        Fecha = fechaActual,
                        TipoMovimiento = Movimiento.DEBITO,
                        Valor = -900
                    }
                }
            };

            //ACT
            var actual = cuenta.TieneSaldoDisponible( -150);

            //ASSERT
            Assert.False(actual);
        }

        [Fact(DisplayName = "Cuando se consulta Saldo Actual retorna saldo al momento")]
        public void SaldoActual_Monto()
        {
            //ARRANGE
            var fechaActual = DateTime.Now;
            double saldoInicial = 700;
            double montoDebito = -300;
            double montoCredito = 200;
            var cuenta = new Cuenta
            {
                Id = 1,
                SaldoInicial = saldoInicial,
                Movimientos = new List<Movimiento>
                {
                    new Movimiento
                    {
                        Id = 1,
                        Fecha = fechaActual,
                        TipoMovimiento = Movimiento.DEBITO,
                        Valor = montoDebito
                    },
                    new Movimiento
                    {
                        Id = 2,
                        Fecha = fechaActual,
                        TipoMovimiento = Movimiento.CREDITO,
                        Valor = montoCredito
                    }
                }
            };

            //ACT
            var actual = cuenta.SaldoActual();

            //ASSERT
            Assert.Equal(saldoInicial+montoCredito+montoDebito, actual);
        }
    }
}
