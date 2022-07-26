using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;

namespace Application.UseCases.MappingDTO
{
    public class ApiResultProfile : Profile
    {
        public ApiResultProfile()
        {
            CreateMap(typeof(IEnumerable<ApiResultDTO<SdCompanyDTO>>), typeof(IEnumerable<ApiResult<IrisSdCompany>>)).ConvertUsing(typeof(Converter<SdCompanyDTO, IrisSdCompany>));
            CreateMap(typeof(IEnumerable<ApiResult<IrisSdCompany>>), typeof(IEnumerable<ApiResultDTO<SdCompanyDTO>>)).ConvertUsing(typeof(Converter<IrisSdCompany, SdCompanyDTO>));

            CreateMap(typeof(IEnumerable<ApiResultDTO<SdCategoryDTO>>), typeof(IEnumerable<ApiResult<IrisSdCategory>>)).ConvertUsing(typeof(Converter<SdCategoryDTO, IrisSdCategory>));
            CreateMap(typeof(IEnumerable<ApiResult<IrisSdCategory>>), typeof(IEnumerable<ApiResultDTO<SdCategoryDTO>>)).ConvertUsing(typeof(Converter<IrisSdCategory, SdCategoryDTO>));

            CreateMap(typeof(IEnumerable<ApiResultDTO<SdServiceDTO>>), typeof(IEnumerable<ApiResult<IrisSdService>>)).ConvertUsing(typeof(Converter<SdServiceDTO, IrisSdService>));
            CreateMap(typeof(IEnumerable<ApiResult<IrisSdService>>), typeof(IEnumerable<ApiResultDTO<SdServiceDTO>>)).ConvertUsing(typeof(Converter<IrisSdService, SdServiceDTO>));

            CreateMap(typeof(IEnumerable<ApiResultDTO<SdSlaDTO>>), typeof(IEnumerable<ApiResult<IrisSdSla>>)).ConvertUsing(typeof(Converter<SdSlaDTO, IrisSdSla>));
            CreateMap(typeof(IEnumerable<ApiResult<IrisSdSla>>), typeof(IEnumerable<ApiResultDTO<SdSlaDTO>>)).ConvertUsing(typeof(Converter<IrisSdSla, SdSlaDTO>));
        }
    }
}
