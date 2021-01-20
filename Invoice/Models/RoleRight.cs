using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class RoleRight
    {
        public Guid CompId { get; set; }
        public int RoleId { get; set; }
        public Guid ControlId { get; set; }
        public bool? Enabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Role Role { get; set; }
    }
}
