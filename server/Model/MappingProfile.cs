using AutoMapper;
using Server.Model.Data;
using Server.Model.DTO;

namespace Server.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<Employer, EmployerDto>();
            CreateMap<EmployerDto, Employer>();
        }
    }
}
