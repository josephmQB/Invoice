using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class AuditTrail
    {
        public Guid CompId { get; set; }
        public Guid AuditId { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }

        public virtual UserAdministration UserAdministration { get; set; }
    }
}
