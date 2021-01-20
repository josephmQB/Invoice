using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class InvoiceReceipt
    {
        public Guid CompId { get; set; }
        public Guid InvoiceId { get; set; }
        public string InvRcptId { get; set; }
        public DateTime? RcptDate { get; set; }
        public decimal? ReceiptAmt { get; set; }
        public short? Mode { get; set; }
        public string BankName { get; set; }
        public string BankAcno { get; set; }
        public string ReceiptParticulars { get; set; }
        public string SignedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
