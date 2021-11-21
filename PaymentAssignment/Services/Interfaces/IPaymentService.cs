using PaymentAssignement.ViewModels;

namespace PaymentAssignement.Services.Interfaces
{
    public interface IPaymentService
    {
        bool GetPaymentResult(TransactionViewModel transaction);
    }
}
