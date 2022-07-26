using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdService
    {
        public IrisSdService()
        {
            IrisSdCategories = new HashSet<IrisSdCategory>();
        }

        public long Id { get; set; }
        public long SdCompId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual IrisSdCompany SdComp { get; set; } = null!;
        public virtual ICollection<IrisSdCategory> IrisSdCategories { get; set; }
    }
}
