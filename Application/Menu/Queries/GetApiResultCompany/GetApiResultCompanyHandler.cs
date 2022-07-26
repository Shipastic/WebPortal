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

namespace UseCases.Menu.Queries.GetApiResultCompany
{
    public class GetApiResultCompanyHandler : IRequestHandler<GetApiResultCompanyQuery, ApiResult<SdCompanyDTO>>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;

        public GetApiResultCompanyHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }
        public  Task<ApiResult<SdCompanyDTO>> Handle(GetApiResultCompanyQuery apiRes, CancellationToken cancellationToken)
        {

            var companies = mapper.Map<IEnumerable<SdCompanyDTO>>( modelContext.IrisSdCompanies);

            apiRes.apiResult =  ApiResult<SdCompanyDTO>.CreateAsync( companies, apiRes.pageIndex, apiRes.pageSize, apiRes.sortColumn, apiRes.sortOrder, apiRes.filterColumn, apiRes.filterQuery);

            return  apiRes.apiResult;
        }

    }
}
