using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;


namespace Application.UseCases.MappingDTO
{
    public class GrpObjProfile : Profile
    {
        public GrpObjProfile()
        {
            CreateMap<IrisSdGrpObj, SdGrpObjDTO>();
            CreateMap<SdGrpObjDTO, IrisSdGrpObj>();
        }
    }
}
