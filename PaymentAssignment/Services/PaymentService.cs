using PaymentAssignement.Constants;
using PaymentAssignement.PaymentProcessors.Interfaces;
using PaymentAssignement.Services.Interfaces;

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

        public bool GetPaymentResult(int accountId)
        {
            var bankName = _dataService.GetAccountById(accountId)?.BankName;
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
    }
}
