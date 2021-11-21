using System.Collections.Generic;

namespace PaymentAssignement.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Consultant> Consultants { get; set; }
    }
}
