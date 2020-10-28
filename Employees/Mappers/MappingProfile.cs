using AutoMapper;
using Employees.Data.Models;
using Employees.ModelsDTO;
using System.Collections.Generic;

namespace Employees.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Positions
            CreateMap<Position, PositionDTO>();
            CreateMap<PositionDTO, Position>()
                .ForMember(dest => dest.EmployeePositions, opt => opt.MapFrom( src=> new List<EmployeePosition>()));
        }
    }
}