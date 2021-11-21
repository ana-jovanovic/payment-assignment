using PaymentAssignement.Services.Interfaces;
using PaymentAssignement.ViewModels;
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
