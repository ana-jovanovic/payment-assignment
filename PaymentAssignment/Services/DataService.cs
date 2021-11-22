using PaymentAssignement.Context;
using PaymentAssignement.Context.Models;
using PaymentAssignement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentAssignement.Services
{
    public class DataService : IDataService
    {
        private readonly PaymentAssignmentContext _context;

        public DataService(PaymentAssignmentContext context)
        {
            _context = context;
        }

        public IList<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public IList<Transaction> GetUnpaidTransactions()
        {
            return GetAllTransactions().Where(t => !t.IsPaid).ToList();
        }

        public IList<Transaction> GetPaidTransactionsByDate(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                return GetPaidTransactions();
            }
            else if (string.IsNullOrEmpty(startDate))
            {
                return GetPaidTransactions().Where(t => t.Date <= Convert.ToDateTime(endDate)).ToList();
            }
            else if (string.IsNullOrEmpty(endDate))
            {
                return GetPaidTransactions().Where(t => t.Date >= Convert.ToDateTime(startDate)).ToList();
            }
            else
            {
                return GetPaidTransactions().Where(t => t.Date >= Convert.ToDateTime(startDate) && t.Date <= Convert.ToDateTime(endDate)).ToList();
            }
        }

        public Transaction GetTransactionById(int id)
        {
            return GetAllTransactions().FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTransaction(int id)
        {
            var dbTransaction = GetTransactionById(id);
            if (dbTransaction != null)
            {
                dbTransaction.Date = DateTime.Now;
                dbTransaction.IsPaid = true;

                _context.SaveChanges();
            }
        }

        public IList<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public IList<Consultant> GetAllConsultants()
        {
            return _context.Consultants.ToList();
        }

        public IList<Project> GetAllProjects()
        {
            return _context.Projects.ToList();

        }

        public IList<Vendor> GetAllVendors()
        {
            return _context.Vendors.ToList();
        }

        private IList<Transaction> GetPaidTransactions()
        {
            return GetAllTransactions().Where(t => t.IsPaid).ToList();
        }
    }
}
