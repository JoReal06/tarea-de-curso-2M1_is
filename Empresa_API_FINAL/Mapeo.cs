﻿using AutoMapper;
using SharedModels;
using SharedModels.Dto;

namespace Empresa_API_FINAL
{
    public class Mapeo:Profile
    {
        public Mapeo()
        {
            CreateMap<Empleado, EmpleadoCreateDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoReadDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoUpdateDto>().ReverseMap();
            CreateMap<Deducciones, DeduccionesCreateDto>().ReverseMap();
            CreateMap<Deducciones, DeduccionesReadDto>().ReverseMap();
            CreateMap<Deducciones, DeduccionesUpdateDto>().ReverseMap();
            CreateMap<Ingresos, IngresosCreateDto>().ReverseMap();
            CreateMap<Ingresos,IngresosReadDto>().ReverseMap();
            CreateMap<Ingresos, IngresosUpdateDto>().ReverseMap();
            CreateMap<Nomina, NominaCreateDto>().ReverseMap();
            CreateMap<Nomina, NominaReadDto>().ReverseMap();
            CreateMap<Nomina, NominaUpdateDto>().ReverseMap();
            CreateMap<Usuario, RegistrosUsuariosDto>().ReverseMap();
        }
    }
}
