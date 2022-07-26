using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.DTO;
using MediatR;

namespace UseCases.Menu.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<IEnumerable<SdCompanyDTO>>
    {
        public IEnumerable<SdCompanyDTO>? sdCompanyDTOs { get; set; }
    }
}
