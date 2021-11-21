using PaymentAssignement.Processors.Interfaces;

namespace PaymentAssignement.Processors
{
    public class PaySimple : IPaySimple
    {
        public bool ProcessPayment()
        {
            return true;
        }
    }
}