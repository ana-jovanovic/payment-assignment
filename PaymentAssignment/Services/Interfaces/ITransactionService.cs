using PaymentAssignement.Models;
using PaymentAssignement.ViewModels;
using System.Collections.Generic;

namespace PaymentAssignement.Services.Interfaces
{
    public interface ITransactionService
    {
        IList<Transaction> GetUnpaidTransactions();
        IList<VendorPaidAmountViewModel> GetVendorsPaidAmount(string startDate, string endDate);
    }
}
