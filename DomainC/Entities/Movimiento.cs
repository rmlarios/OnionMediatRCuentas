using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DomainC.Globalization;
using DomainC.Results;


namespace Domain
{
    public class Movimiento: Base
    {
        public const string CREDITO = "Crédito";
        public const string DEBITO = "Débito";
        public Movimiento()
        {
            
        }
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El Tipo de Movimiento es Requerido")]
        public string TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El Valor es Requerido")]
        public double Valor { get; set; }
        public double Saldo { get; set; }
        
        public virtual Cuenta Cuenta { get; set; }

        public bool EsCredito => TipoMovimiento == CREDITO;
        public bool EsDebito => TipoMovimiento == DEBITO;

        public virtual DomainValidation Validar(int idMovimientoEditar=0)
        {
            var result = new DomainValidation();

            if (EsDebito && Valor >= 0)
            {
                result.Errors.Add(MovimientoStrings.ErrorValorDebitoPositivo);
            }

            if (EsCredito && Valor <= 0)
            {
                result.Errors.Add(MovimientoStrings.ErrorValorCreditoNegativo);
            }

            if (EsDebito)
            {
                var resultPermitidoDebito = EsPermitidoDebito(idMovimientoEditar);
                result.Errors.AddRange(resultPermitidoDebito.Errors);
            }


            return result;
        }
        public virtual DomainValidation EsPermitidoDebito(int idMovimientoEditar=0)
        {
            var result = new DomainValidation();

            if(!Cuenta.TieneSaldoDisponible(Valor,idMovimientoEditar))
                result.Errors.Add("Saldo No disponible.");

            if(Cuenta.LimiteDiarioSuperado(Fecha,Valor,idMovimientoEditar))
                result.Errors.Add("Cupo diario excedido.");

            return result;
        }

        public void CalcularSaldo()
        {
            Saldo = Cuenta.SaldoActual(Id) + Valor;
        }
    }
}
