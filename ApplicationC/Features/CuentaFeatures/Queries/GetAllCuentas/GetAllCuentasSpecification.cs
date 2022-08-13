using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Specifications;

namespace ApplicationC.Features.CuentaFeatures.Queries.GetAllCuentas
{
    public class GetAllCuentasSpecification : RequestSpecification
    {
        public bool? FilterEstado { get; set; }
        public int? FilterIdCliente { get; set; }
    }
}
