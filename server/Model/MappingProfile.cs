using AutoMapper;
using Server.Model.Data;
using Server.Model.DTO;

namespace Server.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(c => c.CompanyId));

            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.CompanyId,
                           opt => opt.Ignore());

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(c => c.CompanyId));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.CompanyId,
                           opt => opt.Ignore());
        }
    }
}
