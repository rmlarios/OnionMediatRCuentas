using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace ApplicationC.Parametrics
{
    public class TipoMovimiento
    {
        public const string CREDITO = Movimiento.CREDITO;
        public const string DEBITO = Movimiento.DEBITO;

        public static readonly string[] TiposMovimiento = { CREDITO, DEBITO };
    }
}
