using AutoMapper;
using SharedModels;
using SharedModels.Dto;

namespace Empresa_API
{
    public class Mapeado: Profile
    {
        public Mapeado()
        {
            CreateMap<Empleado, EmpleadoCreateDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoReadDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoUpdateDto>().ReverseMap();

        }
    }
}
