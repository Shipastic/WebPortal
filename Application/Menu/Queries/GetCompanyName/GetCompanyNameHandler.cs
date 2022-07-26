using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.DTO;
using Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Menu.Queries.GetCompanyName
{
    public class GetCompanyNameHandler : IRequestHandler<GetCompanyNameQuery, SdCompanyDTO>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;

        public GetCompanyNameHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }
        public async Task<SdCompanyDTO> Handle(GetCompanyNameQuery request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<SdCompanyDTO>(await modelContext.IrisSdCompanies.Where(i => i.Id.Equals(request.Id)).FirstOrDefaultAsync());

            
            return company;
        }
    }
}
