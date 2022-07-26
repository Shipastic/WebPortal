using Application.UseCases.DTO;
using AutoMapper;
using Entities.Models;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;

namespace UseCases.Menu.Queries.GetApiResultCategory
{
    public class GetApiResultCategoryHandler : IRequestHandler<GetApiResultCategoryQuery, ApiResult<SdCategoryDTO>>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;

        public GetApiResultCategoryHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }
        public Task<ApiResult<SdCategoryDTO>> Handle(GetApiResultCategoryQuery apiRes, CancellationToken cancellationToken)
        {

            var categories = mapper.Map<IEnumerable<SdCategoryDTO>>(modelContext.IrisSdCategories);

            apiRes.apiResult = ApiResult<SdCategoryDTO>.CreateAsync(categories, apiRes.pageIndex, apiRes.pageSize, apiRes.sortColumn, apiRes.sortOrder, apiRes.filterColumn, apiRes.filterQuery);

            return apiRes.apiResult;
        }
    }
}
