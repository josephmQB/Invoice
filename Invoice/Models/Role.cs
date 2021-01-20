using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleRights = new HashSet<RoleRight>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public Guid CompId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Company Comp { get; set; }
        public virtual ICollection<RoleRight> RoleRights { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
