using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class GrpLinkProfile : Profile
    {
        public GrpLinkProfile()
        {
            CreateMap<IrisSdGrpLink, SdGrpLinkDTO>();
            CreateMap<SdGrpLinkDTO, IrisSdGrpLink>();
        }
    }
}
