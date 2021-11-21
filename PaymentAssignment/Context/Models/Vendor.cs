using System.Collections.Generic;

namespace PaymentAssignement.Context.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Consultant> Consultants { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Vendor()
        {
            Consultants = new HashSet<Consultant>();
        }
    }
}
