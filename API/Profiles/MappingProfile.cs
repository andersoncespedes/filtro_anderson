using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Pedido, DtoPedido1>().ReverseMap();
            CreateMap<Cliente, Cliente2dto>()
            .ForMember(e => e.NombreRep, dest => dest.MapFrom(e => e.Empleado.Nombre))
            .ForMember(e => e.Ciudad, dest => dest.MapFrom(e => e.Empleado.Oficina.Ciudad))
            .ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>()
            .ForMember(e => e.CantidadVendida, dest => dest.MapFrom(e => e.DetallePedidos.Select(e => e.Cantidad).Sum()))
            .ReverseMap();
            CreateMap<Producto, ProductMasIvaDto>()
            .ForMember(e => e.Total, e => e.MapFrom(op => op.DetallePedidos.Select(e => e.PrecioUnidad).Sum()))
            .ForMember(e => e.TotalIva, dest => dest.MapFrom(e => e.DetallePedidos.Select(e => e.PrecioUnidad).Sum() * .32))
            .ForMember(e => e.UnidadesVendidas, dest => dest.MapFrom(e => e.DetallePedidos.Select(e => e.Cantidad).Sum()))
            .ReverseMap();
            CreateMap<Cliente, ClienteDto>()
            .ForMember(e => e.PedidoCant, dest => dest.MapFrom(e => e.Pedidos.Count()))
            .ReverseMap();
            CreateMap<Cliente, ClienteWithEmpDto>()
            .ForMember(e => e.NombreRep, dest => dest.MapFrom(e => e.Empleado.Nombre))
            .ForMember(e => e.Ciudad, dest => dest.MapFrom(e => e.Empleado.Oficina.Ciudad))
            .ForMember(e => e.ApellidoRep, dest => dest.MapFrom(e => e.Empleado.Apellido1))
            .ReverseMap();
            CreateMap<Empleado, EmpleadoWithJefe>()
            .ForMember(e => e.Jefe, dest => dest.MapFrom(e => e.Jefe.Nombre))
            .ReverseMap();
            CreateMap<Producto, NoPedProdDto>()
            .ForMember(e => e.Imagen, dest => dest.MapFrom(e => e.GamaProducto.Imagen))
            .ReverseMap();


        }
    }
}