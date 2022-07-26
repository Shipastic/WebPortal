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

namespace UseCases.Menu.Queries.GetCompanyById
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, SdCompanyDTO>
    {
        private readonly IMapper mapper;

        private readonly IModelContext modelContext;

        public GetCompanyByIdHandler(IMapper _mapper, IModelContext _modelContext)
        {
            mapper = _mapper;

            modelContext = _modelContext;
        }
        public async Task<SdCompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<SdCompanyDTO>(await modelContext.IrisSdCompanies.Where(i => i.Id.Equals(request.Id)).FirstOrDefaultAsync());

            
            return company;
        }
    }
}
