using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Invoice.Models
{
    public partial class InvoiceDBContext : DbContext
    {
        public InvoiceDBContext()
        {
        }

        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<IdentitySequence> IdentitySequences { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceReceipt> InvoiceReceipts { get; set; }
        public virtual DbSet<Proforma> Proformas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleRight> RoleRights { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<UserAdministration> UserAdministrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=InvoiceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.AuditId });

                entity.ToTable("Audit_Trail");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.AuditId).HasColumnName("audit_id");

                entity.Property(e => e.Action)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Module)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("module");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.UserAdministration)
                    .WithMany(p => p.AuditTrails)
                    .HasForeignKey(d => new { d.CompId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audit_TrailUser_Administration");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompId);

                entity.ToTable("Company");

                entity.Property(e => e.CompId)
                    .ValueGeneratedNever()
                    .HasColumnName("comp_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CompRegId1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("comp_reg_id1");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contact_no");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.District)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.InvBank)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("inv_bank");

                entity.Property(e => e.InvBankAcno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("inv_bank_acno");

                entity.Property(e => e.InvBankDetails)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("inv_bank_details");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pincode");

                entity.Property(e => e.SalesTax1Perc)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("sales_tax1_perc");

                entity.Property(e => e.SalesTax2Perc)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("sales_tax2_perc");

                entity.Property(e => e.SalesTax3Perc)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("sales_tax3_perc");

                entity.Property(e => e.SalesTax4Perc)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("sales_tax4_perc");

                entity.Property(e => e.SalesTax5Perc)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("sales_tax5_perc");

                entity.Property(e => e.SalesTaxId1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sales_tax_id1");

                entity.Property(e => e.SigningAuthority)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("signing_authority");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.CustId });

                entity.ToTable("Customer");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CompRegId1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("comp_reg_id1");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.District)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PaymentTerms)
                    .IsUnicode(false)
                    .HasColumnName("payment_terms");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pincode");

                entity.Property(e => e.PocBilling)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("poc_billing");

                entity.Property(e => e.PocBillingEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("poc_billing_email");

                entity.Property(e => e.PocEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("poc_email");

                entity.Property(e => e.PocMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("poc_mobile");

                entity.Property(e => e.PointOfContact)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("point_of_contact");

                entity.Property(e => e.SalesTaxId1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sales_tax_id1");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("website");

                entity.HasOne(d => d.Comp)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerCompany");
            });

            modelBuilder.Entity<IdentitySequence>(entity =>
            {
                entity.HasKey(e => e.CompId);

                entity.ToTable("Identity_Sequences");

                entity.Property(e => e.CompId)
                    .ValueGeneratedNever()
                    .HasColumnName("comp_id");

                entity.Property(e => e.CrNoteNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cr_note_no");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("invoice_no");

                entity.Property(e => e.ProInvNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pro_inv_no");

                entity.HasOne(d => d.Comp)
                    .WithOne(p => p.IdentitySequence)
                    .HasForeignKey<IdentitySequence>(d => d.CompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Identity_SequencesCompany");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.InvoiceId });

                entity.ToTable("Invoice");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.AmtInWords)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("amt_in_words");

                entity.Property(e => e.CrNoteDescription)
                    .IsUnicode(false)
                    .HasColumnName("cr_note_description");

                entity.Property(e => e.CrNoteNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cr_note_no");

                entity.Property(e => e.CrNoteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("cr_note_on");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustAdrs)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cust_adrs");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.CustName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cust_po");

                entity.Property(e => e.CustSalesTaxId1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cust_sales_tax_id1");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("grand_total");

                entity.Property(e => e.InvAmount)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("inv_amount");

                entity.Property(e => e.InvDate)
                    .HasColumnType("date")
                    .HasColumnName("inv_date");

                entity.Property(e => e.InvDescription)
                    .IsUnicode(false)
                    .HasColumnName("inv_description");

                entity.Property(e => e.InvDiscount)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("inv_discount");

                entity.Property(e => e.InvEmailedTo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("inv_emailed_to");

                entity.Property(e => e.InvSacCode).HasColumnName("inv_sac_code");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("invoice_no");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PaymentInstruction)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("payment_instruction");

                entity.Property(e => e.ProformaId).HasColumnName("proforma_id");

                entity.Property(e => e.SalesTax1Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax1_amt");

                entity.Property(e => e.SalesTax2Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax2_amt");

                entity.Property(e => e.SalesTax3Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax3_amt");

                entity.Property(e => e.SalesTax4Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax4_amt");

                entity.Property(e => e.SalesTax5Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax5_amt");

                entity.Property(e => e.SigningAuthority)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("signing_authority");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => new { d.CompId, d.CustId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceCustomer");

                entity.HasOne(d => d.Proforma)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => new { d.CompId, d.ProformaId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceProforma");
            });

            modelBuilder.Entity<InvoiceReceipt>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.InvoiceId, e.InvRcptId });

                entity.ToTable("Invoice_receipt");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.InvRcptId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("inv_rcpt_id");

                entity.Property(e => e.BankAcno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bank_acno");

                entity.Property(e => e.BankName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("bank_name");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Mode).HasColumnName("mode");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.RcptDate)
                    .HasColumnType("date")
                    .HasColumnName("rcpt_date");

                entity.Property(e => e.ReceiptAmt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("receipt_amt");

                entity.Property(e => e.ReceiptParticulars)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("receipt_particulars");

                entity.Property(e => e.SignedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("signed_by");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceReceipts)
                    .HasForeignKey(d => new { d.CompId, d.InvoiceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_receiptInvoice");
            });

            modelBuilder.Entity<Proforma>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.ProformaId });

                entity.ToTable("Proforma");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.ProformaId).HasColumnName("proforma_id");

                entity.Property(e => e.AmtInWords)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("amt_in_words");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustAdrs)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cust_adrs");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.CustName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cust_po");

                entity.Property(e => e.CustSalesTaxId1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cust_sales_tax_id1");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("grand_total");

                entity.Property(e => e.InvAmount)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("inv_amount");

                entity.Property(e => e.InvDescription)
                    .IsUnicode(false)
                    .HasColumnName("inv_description");

                entity.Property(e => e.InvDiscount)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("inv_discount");

                entity.Property(e => e.InvRecurring).HasColumnName("inv_recurring");

                entity.Property(e => e.InvSacCode).HasColumnName("inv_sac_code");

                entity.Property(e => e.InvType).HasColumnName("inv_type");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PaymentInstruction)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("payment_instruction");

                entity.Property(e => e.ProEmailedTo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pro_emailed_to");

                entity.Property(e => e.ProInvDate)
                    .HasColumnType("datetime")
                    .HasColumnName("pro_inv_date");

                entity.Property(e => e.ProInvNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pro_inv_no");

                entity.Property(e => e.SalesTax1Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax1_amt");

                entity.Property(e => e.SalesTax2Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax2_amt");

                entity.Property(e => e.SalesTax3Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax3_amt");

                entity.Property(e => e.SalesTax4Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax4_amt");

                entity.Property(e => e.SalesTax5Amt)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("sales_tax5_amt");

                entity.Property(e => e.SigningAuthority)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("signing_authority");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Proformas)
                    .HasForeignKey(d => new { d.CompId, d.CustId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProformaCustomer");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.RoleId });

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.HasOne(d => d.Comp)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.CompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyRoles");
            });

            modelBuilder.Entity<RoleRight>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.RoleId, e.ControlId });

                entity.ToTable("Role_Rights");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ControlId).HasColumnName("control_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRights)
                    .HasForeignKey(d => new { d.CompId, d.RoleId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_RightsRoles");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.UserId, e.RoleId, e.AssignedOn });

                entity.ToTable("Role_User");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.AssignedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("assigned_on");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => new { d.CompId, d.RoleId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_UserRole");

                entity.HasOne(d => d.UserAdministration)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => new { d.CompId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_UserUser_Administration");
            });

            modelBuilder.Entity<UserAdministration>(entity =>
            {
                entity.HasKey(e => new { e.CompId, e.UserId });

                entity.ToTable("User_Administration");

                entity.Property(e => e.CompId).HasColumnName("comp_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.District)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pincode");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Comp)
                    .WithMany(p => p.UserAdministrations)
                    .HasForeignKey(d => d.CompId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUser_Administration");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
