using PaymentAssignement.Context.Models;
using System.Collections.Generic;

namespace PaymentAssignement.Services.Interfaces
{
    public interface IDataService
    {
        IList<Transaction> GetUnpaidTransactions();
        IList<Transaction> GetPaidTransactionsByDate(string startDate, string endDate);
        Transaction GetTransactionById(int id);
        void UpdateTransaction(int id);
        IList<Account> GetAllAccounts();
        Account GetAccountById(int id);
        IList<Consultant> GetAllConsultants();
        IList<Project> GetAllProjects();
        IList<Vendor> GetAllVendors();
    }
}
