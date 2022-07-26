using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class IrisSdCompany
    {
        public IrisSdCompany()
        {
            IrisSdServices = new HashSet<IrisSdService>();
        }

        public long Id { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }
        public long? CntId { get; set; }

        public virtual ICollection<IrisSdService> IrisSdServices { get; set; }
    }
}
