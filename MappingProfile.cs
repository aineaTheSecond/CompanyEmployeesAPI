using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployeesAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
