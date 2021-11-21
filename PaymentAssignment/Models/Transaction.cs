namespace PaymentAssignement.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
    }
}