using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<IrisSdCompany, SdCompanyDTO>();
            CreateMap<SdCompanyDTO, IrisSdCompany>();
        }
    }
}
