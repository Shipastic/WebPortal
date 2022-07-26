using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<IrisSdService, SdServiceDTO>();
            CreateMap<SdServiceDTO, IrisSdService>();
        }
    }
}
