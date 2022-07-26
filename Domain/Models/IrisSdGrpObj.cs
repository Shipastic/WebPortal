using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdGrpObj
    {
        public IrisSdGrpObj()
        {
            IrisSdGrpLinks = new HashSet<IrisSdGrpLink>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<IrisSdGrpLink> IrisSdGrpLinks { get; set; }
    }
}
