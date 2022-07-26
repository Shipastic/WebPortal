using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Interfaces.DataAccess.Interfaces.Infrastructure
{
    public interface IModelContext
    {
        DbSet<Contractor> Contractors { get; }
        DbSet<IrisSdCompany> IrisSdCompanies { get; }
        DbSet<IrisSdCategory> IrisSdCategories { get; }
        DbSet<IrisSdService> IrisSdServices { get; }
        DbSet<IrisSdSla> IrisSdSlas { get; }
        DbSet<IrisSdGrpObj> IrisSdGrpObjs { get; }
        DbSet<IrisSdGrpLink> IrisSdGrpLinks { get; }
        Task<int> SaveChangeAsync(CancellationToken token = default);
    }
}