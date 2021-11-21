using System;

namespace PaymentAssignement.ViewModels
{
    public class TransactionViewModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Accountname { get; set; }
        public string ConsultantName { get; set; }
        public string ProjectName { get; set; }
        public string VendorName { get; set; }
    }
}