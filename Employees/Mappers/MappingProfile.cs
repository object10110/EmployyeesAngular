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


            //EmployeePosition
            CreateMap<EmployeePositionDTO, EmployeePosition>()
                .ForMember(dest => dest.DateOfAppointment, opt => opt.MapFrom(src => src.DateOfAppointment.Value));

            CreateMap<EmployeePosition, EmployeePositionDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Employee.Surname))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name));
        }
    }
}