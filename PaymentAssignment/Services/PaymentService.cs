using PaymentAssignement.Constants;
using PaymentAssignement.Processors.Interfaces;
using PaymentAssignement.Services.Interfaces;
using PaymentAssignement.ViewModels;

namespace PaymentAssignement.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IDataService _dataService;
        private readonly ISquare _square;
        private readonly IPaySimple _paySimple;

        public PaymentService(IDataService dataService, ISquare square, IPaySimple paySimple)
        {
            _dataService = dataService;
            _square = square;
            _paySimple = paySimple;
        }

        public bool GetPaymentResult(TransactionViewModel transaction)
        {
            var dbTransaction = _dataService.GetTransactionById(transaction.Id);
            if (dbTransaction != null)
            {
                var bankName = _dataService.GetAccountById(dbTransaction.AccountId)?.BankName;
                switch (bankName)
                {
                    case PaymentConstants.Banks.USBank:
                    case PaymentConstants.Banks.BankOfAmerica:
                        return _square.ProcessPayment();
                    case PaymentConstants.Banks.JPMorgan:
                        return _paySimple.ProcessPayment();
                    default:
                        return false;
                }
            }

            return false;
        }
    }
}