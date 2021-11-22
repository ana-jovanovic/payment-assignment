using PaymentAssignement.Models;
using PaymentAssignement.ViewModels;
using System.Collections.Generic;

namespace PaymentAssignement.Services.Interfaces
{
    public interface ITransactionsService
    {
        IList<Transaction> GetUnpaidTransactions();
        bool PayTransaction(int transactionId, int accountId);
        IList<VendorPaidAmountViewModel> GetVendorsPaidAmount(string startDate, string endDate);
    }
}
