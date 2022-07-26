using AutoMapper;
using MediatR;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.DTO;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Menu.Queries.GetCompanies
{
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<SdCompanyDTO>>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;

        public GetCompaniesHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }

        public async Task<IEnumerable<SdCompanyDTO>> Handle(GetCompaniesQuery company, CancellationToken cancellationToken)
        {
            var companies = mapper.Map<IEnumerable<SdCompanyDTO>>(await modelContext.IrisSdCompanies.ToListAsync());

            company.sdCompanyDTOs =  companies;

            return  company.sdCompanyDTOs;
        }
    }
}
