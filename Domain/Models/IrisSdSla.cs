using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdSla
    {
        public IrisSdSla()
        {
            IrisSdGrpLinks = new HashSet<IrisSdGrpLink>();
        }

        public long Id { get; set; }
        public long SdCatId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual IrisSdCategory SdCat { get; set; } = null!;
        public virtual ICollection<IrisSdGrpLink> IrisSdGrpLinks { get; set; }
    }
}
