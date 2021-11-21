using System.Collections.Generic;

namespace PaymentAssignement.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public IList<Vendor> Vendors { get; set; }
    }
}
