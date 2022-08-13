using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ApplicationC.Parametrics
{
    public static class TipoCuenta
    {
        public const string AHORRO = "Ahorro";
        public const string CORRIENTE = "Corriente";

        public static readonly string[] TiposCuenta = {AHORRO, CORRIENTE};
    }
}
