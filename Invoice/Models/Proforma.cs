using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class Proforma
    {
        public Proforma()
        {
            Invoices = new HashSet<Invoice>();
        }

        public Guid CompId { get; set; }
        public Guid ProformaId { get; set; }
        public Guid CustId { get; set; }
        public string ProInvNo { get; set; }
        public DateTime? ProInvDate { get; set; }
        public short? InvType { get; set; }
        public bool? Deleted { get; set; }
        public bool? InvRecurring { get; set; }
        public string CustName { get; set; }
        public string CustAdrs { get; set; }
        public string CustSalesTaxId1 { get; set; }
        public string CustPo { get; set; }
        public string InvDescription { get; set; }
        public int? InvSacCode { get; set; }
        public decimal? InvAmount { get; set; }
        public decimal? InvDiscount { get; set; }
        public decimal? SalesTax1Amt { get; set; }
        public decimal? SalesTax2Amt { get; set; }
        public decimal? SalesTax3Amt { get; set; }
        public decimal? SalesTax4Amt { get; set; }
        public decimal? SalesTax5Amt { get; set; }
        public decimal? GrandTotal { get; set; }
        public string AmtInWords { get; set; }
        public string PaymentInstruction { get; set; }
        public string SigningAuthority { get; set; }
        public string ProEmailedTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Customer C { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
