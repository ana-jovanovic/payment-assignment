using System.Collections.Generic;

namespace PaymentAssignement.Context.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Consultant()
        {
            Vendors = new HashSet<Vendor>();
        }
    }
}
