using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Proformas = new HashSet<Proforma>();
        }

        public Guid CompId { get; set; }
        public Guid CustId { get; set; }
        public bool? Active { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string PointOfContact { get; set; }
        public string PocMobile { get; set; }
        public string PocEmail { get; set; }
        public string PocBilling { get; set; }
        public string PocBillingEmail { get; set; }
        public string CompRegId1 { get; set; }
        public string SalesTaxId1 { get; set; }
        public string PaymentTerms { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Company Comp { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Proforma> Proformas { get; set; }
    }
}
