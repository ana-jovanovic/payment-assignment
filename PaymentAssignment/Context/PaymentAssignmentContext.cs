using PaymentAssignement.Context.Models;
using System.Data.Entity;

namespace PaymentAssignement.Context
{
    public class PaymentAssignmentContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public PaymentAssignmentContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>()
                .HasMany(s => s.Consultants)
                .WithMany(c => c.Vendors)
                .Map(cs =>
                {
                    cs.MapLeftKey("VendorId");
                    cs.MapRightKey("ConsultantId");
                    cs.ToTable("VendorConsultant");
                });
        }
    }
}
