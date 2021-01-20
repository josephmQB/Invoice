using System;
using System.Collections.Generic;

#nullable disable

namespace Invoice.Models
{
    public partial class IdentitySequence
    {
        public Guid CompId { get; set; }
        public string ProInvNo { get; set; }
        public string InvoiceNo { get; set; }
        public string CrNoteNo { get; set; }

        public virtual Company Comp { get; set; }
    }
}
