using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.DTO;
using MediatR;

namespace UseCases.Menu.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<SdCompanyDTO>
    {
        public long Id { get; set; }
    }
}
