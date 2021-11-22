using PaymentAssignement.PaymentProcessors.Interfaces;

namespace PaymentAssignement.PaymentProcessors
{
    public class PaySimple : IPaySimple
    {
        public bool ProcessPayment()
        {
            return true;
        }
    }
}