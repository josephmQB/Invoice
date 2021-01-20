using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class UserAdministration
    {
        public UserAdministration()
        {
            AuditTrails = new HashSet<AuditTrail>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public Guid CompId { get; set; }
        public Guid UserId { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Company Comp { get; set; }
        public virtual ICollection<AuditTrail> AuditTrails { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
