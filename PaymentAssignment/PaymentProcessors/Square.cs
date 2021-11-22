using PaymentAssignement.PaymentProcessors.Interfaces;

namespace PaymentAssignement.Processors
{
    public class Square : ISquare
    {
        public bool ProcessPayment()
        {
            return true;
        }
    }
}