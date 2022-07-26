using Application.UseCases.DTO;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Menu.Queries.GetApiResultCompany
{
    public class GetApiResultCompanyQuery : IRequest<ApiResult<SdCompanyDTO>>
    {
        public  Task<ApiResult<SdCompanyDTO>>? apiResult { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get;  set ;  }
        public string? sortColumn { get; set; }
        public string? sortOrder { get; set; }
        public string? filterColumn {get; set; }
        public string? filterQuery { get; set; }

    }
}
