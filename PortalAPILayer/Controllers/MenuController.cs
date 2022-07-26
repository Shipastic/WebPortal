using Application.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using MediatR;
using Application.UseCases.Menu.Commands.ShowMenu;
using Application.UseCases.Menu.Queries.GetCompanyName;
using UseCases.Menu.Queries.GetCompanies;
using UseCases.Menu.Queries.GetCompanyById;
using UseCases.Menu.Queries.GetApiResultCompany;
using UseCases.DTO;
using UseCases.Menu.Queries.GetApiResultCategory;
using Microsoft.AspNetCore.Authorization;

namespace PortalAPILayer.Controllers
{
    [ApiController]
    public class MenuController : ControllerBase
    {
        ISender menuService;

        public MenuController(ISender menu)
        {
            menuService = menu;
        }      

        //[HttpGet]
        //[Route("api/Company/Tree")]
        //public async Task<IEnumerable<TreeViewNode>> GetTree()
        //{
        //    var _menu = await menuService.Send(new ShowMenuCommand()); 
            
        //    return _menu;
        //}

        [HttpGet("{id}")]
        [Route("api/Company/InfoCompany/{id}")]

        public async Task<SdCompanyDTO> GetNameCompany(long id)
        {
            
            var name = await menuService.Send(new GetCompanyByIdQuery { Id = id });

            return name;
        }

        [HttpGet]
        [Route("api/Companies/All")]
        public async Task<IEnumerable<SdCompanyDTO>> SdCompanies()
        {
            var comp = await menuService.Send(new GetCompaniesQuery());

            return comp;
        }

        [HttpGet]
        [Route("api/Companies")]
        public async Task<ApiResult<SdCompanyDTO>> ApiResultCompanyAsync(int pageIndex = 0, int pageSize = 10, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null,string? filterQuery = null)
        {
            var apiRes = await menuService.Send(new GetApiResultCompanyQuery { pageIndex = pageIndex, pageSize = pageSize, sortColumn = sortColumn, sortOrder = sortOrder, filterColumn = filterColumn , filterQuery = filterQuery });

            return apiRes;
        }

        [HttpGet]
        [Route("api/Categories")]
        public async Task<ApiResult<SdCategoryDTO>> ApiResultCategoryAsync(int pageIndex = 0, int pageSize = 10, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null, string? filterQuery = null)
        {
            var apiRes = await menuService.Send(new GetApiResultCategoryQuery { pageIndex = pageIndex, pageSize = pageSize, sortColumn = sortColumn, sortOrder = sortOrder, filterColumn = filterColumn, filterQuery = filterQuery });

            return apiRes;
        }
    }
}
