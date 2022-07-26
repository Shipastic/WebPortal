using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdCategory
    {
        public IrisSdCategory()
        {
            IrisSdSlas = new HashSet<IrisSdSla>();
        }

        public long Id { get; set; }
        public long SdServId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }
        public string? Priority { get; set; }

        public virtual IrisSdService SdServ { get; set; } = null!;
        public virtual ICollection<IrisSdSla> IrisSdSlas { get; set; }
    }
}
