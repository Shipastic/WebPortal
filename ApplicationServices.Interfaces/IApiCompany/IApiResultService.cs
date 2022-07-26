using Entities.Models;

namespace ApplicationServices.Interfaces.IApiCompany
{
    public interface IApiResultService
    {
        public Task<ApiResult<IrisSdCompany>> CreateAsync(IEnumerable<IrisSdCompany> source, int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null, string? filterColumn = null, string? filterQuery = null);
    }
}
