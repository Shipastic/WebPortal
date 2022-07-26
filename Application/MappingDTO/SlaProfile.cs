using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class SlaProfile: Profile
    {
        public SlaProfile()
        {
            CreateMap<IrisSdSla, SdSlaDTO>();
            CreateMap<SdSlaDTO, IrisSdSla>();
        }
    }
}
