using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain
{
    public class Cuenta: Base
    {
        public const int LIMITE_RETIRO_DIARIO = 1000;
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }
        [Required(ErrorMessage = "El Número de Cuenta es Requerido")]
        public string NumeroCuenta { get; set; }
        [Required(ErrorMessage = "El Tipo de Cuenta es Requerido")]
        public string TipoCuenta { get; set; }
        [Required(ErrorMessage = "El Saldo Inicial es Requerido")]
        public double SaldoInicial { get; set; }
        [Required(ErrorMessage = "El Número de Cuenta es Requerido")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El Cliente es Requerido")]
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }

        public double SaldoActual(int idMovimientoEditar=0)
        {
            var creditos = Movimientos.Where(m => m.EsCredito && m.Id!=idMovimientoEditar).Sum(m => m.Valor);
            var debitos = Movimientos.Where(m => m.EsDebito && m.Id!= idMovimientoEditar).Sum(m => m.Valor);
            var saldoActual = SaldoInicial + creditos + debitos;

            return saldoActual;
        }

        public bool TieneSaldoDisponible(double montoDebitar, int idMovimientoEditar=0)
        {
            return SaldoActual(idMovimientoEditar) + montoDebitar > 0;
        }

        public bool LimiteDiarioSuperado(DateTime date, double montoDebitar, int idMovimientoEditar=0)
        {
            return ((Movimientos.Where(m => m.EsDebito && m.Fecha.Date == date.Date && m.Id != idMovimientoEditar)
                .Sum(m => m.Valor) + montoDebitar) * -1) > 1000;
        }
    }
}
