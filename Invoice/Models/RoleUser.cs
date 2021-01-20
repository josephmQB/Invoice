using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class RoleUser
    {
        public Guid CompId { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Role Role { get; set; }
        public virtual UserAdministration UserAdministration { get; set; }
    }
}
