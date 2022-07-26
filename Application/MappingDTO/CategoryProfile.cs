
using AutoMapper;
using Entities.Models;
using Application.UseCases.DTO;

namespace Application.UseCases.MappingDTO
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<IrisSdCategory, SdCategoryDTO>();
            CreateMap<SdCategoryDTO, IrisSdCategory>();
        }
    }
}
