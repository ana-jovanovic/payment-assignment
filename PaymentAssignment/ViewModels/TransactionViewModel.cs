using System;

namespace PaymentAssignement.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string ConsultantName { get; set; }
        public string ProjectName { get; set; }
        public string VendorName { get; set; }
    }
}