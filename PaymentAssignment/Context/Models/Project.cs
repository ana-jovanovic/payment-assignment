using System.Collections.Generic;

namespace PaymentAssignement.Context.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
