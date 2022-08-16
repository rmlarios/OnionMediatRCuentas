using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainC.Globalization;
using DomainC.Results;
using Moq;
using Xunit;

namespace Domain.UnitTest.cs.Entities
{
    public class MovimientoTest
    {
        public const string MENSAJE_ERROR = "Error Perzonalidado";
        #region Validar
        [Fact(DisplayName = "Cuando es Debito y el Valor es positivo Retorna Error")]
        public void Validar_Debito_False()
        {
            //ARRANGE
            var mockMovimiento = new Mock<Movimiento>()
            {
                CallBase = true
            };
            mockMovimiento.SetupAllProperties();
            mockMovimiento.Object.Id = 1;
            mockMovimiento.Object.TipoMovimiento = Movimiento.DEBITO;
            mockMovimiento.Object.Valor = 100;

            mockMovimiento.Setup(m => m.EsPermitidoDebito(It.IsAny<int>())).Returns(new DomainValidation());

            //ACT
            var actual = mockMovimiento.Object.Validar();

            //ASSERT
            Assert.True(actual.HasErrors);
            Assert.Equal(MovimientoStrings.ErrorValorDebitoPositivo, actual.Errors.First());
            mockMovimiento.Verify(m=>m.EsPermitidoDebito(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Cuando es Créditp y el Valor es negativo Retorna Error")]
        public void Validar_Credito_False()
        {
            //ARRANGE
            var mockMovimiento = new Mock<Movimiento>()
            {
                CallBase = true
            };
            mockMovimiento.SetupAllProperties();
            mockMovimiento.Object.Id = 1;
            mockMovimiento.Object.TipoMovimiento = Movimiento.CREDITO;
            mockMovimiento.Object.Valor = -100;

            mockMovimiento.Setup(m => m.EsPermitidoDebito(It.IsAny<int>())).Returns(new DomainValidation());

            //ACT
            var actual = mockMovimiento.Object.Validar();

            //ASSERT
            Assert.True(actual.HasErrors);
            Assert.Equal(MovimientoStrings.ErrorValorCreditoNegativo, actual.Errors.First());
            mockMovimiento.Verify(m => m.EsPermitidoDebito(It.IsAny<int>()), Times.Never);
        }
        [Fact(DisplayName = "Cuando es Débito y No se Permite Debitar Retorna Error")]
        public void Validar_DebitoNoPermitido_False()
        {
            //ARRANGE
            var mockMovimiento = new Mock<Movimiento>()
            {
                CallBase = true
            };
            mockMovimiento.SetupAllProperties();
            mockMovimiento.Object.Id = 1;
            mockMovimiento.Object.TipoMovimiento = Movimiento.DEBITO;
            mockMovimiento.Object.Valor = -100;

            mockMovimiento.Setup(m => m.EsPermitidoDebito(It.IsAny<int>())).Returns(new DomainValidation
            {
                Errors = {MENSAJE_ERROR}
            });

            //ACT
            var actual = mockMovimiento.Object.Validar();

            //ASSERT
            Assert.True(actual.HasErrors);
            Assert.Equal(MENSAJE_ERROR, actual.Errors.First());
            mockMovimiento.Verify(m => m.EsPermitidoDebito(It.IsAny<int>()), Times.Once);
        }

        #endregion
    }
}
