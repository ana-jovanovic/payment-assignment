using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAssignement.Context.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }


        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }


        [ForeignKey("Consultant")]
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }


        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }


        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
