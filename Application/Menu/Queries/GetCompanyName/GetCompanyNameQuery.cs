using Application.UseCases.DTO;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Menu.Queries.GetCompanyName
{
    public class GetCompanyNameQuery : IRequest<SdCompanyDTO>
    {
        public int Id { get; set; }
    }
}
