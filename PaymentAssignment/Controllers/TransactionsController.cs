using PaymentAssignement.Services.Interfaces;
using PaymentAssignement.ViewModels;
using System.Web.Mvc;

namespace PaymentAssignement.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionsService _transactionService;

        public TransactionsController(ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }

        public ActionResult UnpaidTransactions()
        {
            var model = _transactionService.GetUnpaidTransactions();
            return View("UnpaidTransactions", model);
        }

        public ActionResult PayTransaction(TransactionViewModel transaction)
        {
            var model = _transactionService.PayTransaction(transaction);
            return View("PaidTransaction", model);
        }

        public ActionResult VendorSearch()
        {
            return View();
        }

        public ActionResult GetVendorsPaidAmount(VendorSearchViewModel viewModel)
        {
            var model = _transactionService.GetVendorsPaidAmount(viewModel.StartDate, viewModel.EndDate);
            return View("VendorPaidAmount", model);
        }
    }
}
