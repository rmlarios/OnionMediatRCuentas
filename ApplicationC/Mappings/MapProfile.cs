using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Features.ClienteFeatures.Commands.CreateCliente;
using ApplicationC.Features.ClienteFeatures.Queries.GetAllClients;
using ApplicationC.Features.CuentaFeatures.Commands;
using ApplicationC.Features.CuentaFeatures.Commands.CreateCuenta;
using ApplicationC.Features.CuentaFeatures.Queries.GetAllCuentas;
using ApplicationC.Features.MovimientoFeatures.Commands.CreateMovimiento;
using ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos;
using ApplicationC.Features.MovimientoFeatures.Queries.GetMovimientosPorCLienteFecha;
using AutoMapper;
using Domain;

namespace ApplicationC.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<GetAllClientesQuery, GetAllClientesSpecification>();
            CreateMap<CreateClienteCommand, Cliente>();

            CreateMap<Cuenta, CuentaDto>().ReverseMap();
            CreateMap<GetAllCuentasQuery, GetAllCuentasSpecification>();
            CreateMap<CreateCuentaCommand, Cuenta>();

            CreateMap<Movimiento, MovimientoDto>();
                
            //    .ForMember(dest => dest.Cuenta, opt =>
            //{
            //    new CuentaDto
            //    {
            //        NumeroCuenta = opt.nu
            //    }
            //});
                
                /*.ForMember(dest => dest.Cuenta, src => src.MapFrom(src => new CuentaDto
            {
                NumeroCuenta = src.Cuenta.NumeroCuenta
            }));*/
            CreateMap<GetAllMovimientosQuery, GetAllMovimientosSpecification>();
            CreateMap<CreateMovimientoCommand, Movimiento>();

            CreateMap<GetMovimientosPorClienteFechaQuery, GetMovimientosPorClienteFechaSpec>();


        }
    }
}
