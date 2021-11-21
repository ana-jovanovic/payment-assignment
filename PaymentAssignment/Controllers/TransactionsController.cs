using PaymentAssignement.Services.Interfaces;
using System.Web.Mvc;

namespace PaymentAssignement.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public ActionResult UnpaidTransactions()
        {
            var model = _transactionService.GetUnpaidTransactions();
            return View("UnpaidTransactions", model);
        }

        public ActionResult GetPaidAmountPerVendor(string startDate, string endDate)
        {
            var model = _transactionService.GetPaidAmountPerVendor(startDate, endDate);
            return View("PaidAmountPerVendor", model);
        }
    }
}
