using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class Company
    {
        public Company()
        {
            Customers = new HashSet<Customer>();
            Roles = new HashSet<Role>();
            UserAdministrations = new HashSet<UserAdministration>();
        }

        public Guid CompId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string SigningAuthority { get; set; }
        public string ContactNo { get; set; }
        public string CompRegId1 { get; set; }
        public string SalesTaxId1 { get; set; }
        public decimal? SalesTax1Perc { get; set; }
        public decimal? SalesTax2Perc { get; set; }
        public decimal? SalesTax3Perc { get; set; }
        public decimal? SalesTax4Perc { get; set; }
        public decimal? SalesTax5Perc { get; set; }
        public string InvBank { get; set; }
        public string InvBankAcno { get; set; }
        public string InvBankDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual IdentitySequence IdentitySequence { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserAdministration> UserAdministrations { get; set; }
    }
}
