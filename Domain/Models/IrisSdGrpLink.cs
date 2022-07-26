using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdGrpLink
    {
        public long Id { get; set; }
        public long GrpObjId { get; set; }
        public long SdSlaId { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual IrisSdGrpObj GrpObj { get; set; } = null!;
        public virtual IrisSdSla SdSla { get; set; } = null!;
    }
}
