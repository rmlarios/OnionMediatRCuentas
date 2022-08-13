using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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

        public DomainValidation EsPermitidoDebito()
        {
            var result = new DomainValidation();

            if(!Cuenta.TieneSaldoDisponible(Valor))
                result.Errors.Add("Saldo No disponible.");

            if(Cuenta.LimiteDiarioSuperado(Fecha,Valor))
                result.Errors.Add("Cupo diario excedido.");

            return result;
        }

        public void CalcularSaldo()
        {
            Saldo = Cuenta.SaldoActual() + Valor;
        }
    }
}
