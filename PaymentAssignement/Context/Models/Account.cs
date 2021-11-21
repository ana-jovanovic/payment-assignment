using System.Collections.Generic;

namespace PaymentAssignement.Context.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string BankName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
