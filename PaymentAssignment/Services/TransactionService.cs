using PaymentAssignement.Context;
using PaymentAssignement.Context.Models;
using PaymentAssignement.Services.Interfaces;
using PaymentAssignement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentAssignement.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly PaymentAssignmentContext _context;

        public TransactionService(PaymentAssignmentContext context)
        {
            _context = context;
        }

        public IList<Models.Transaction> GetUnpaidTransactions()
        {
            var dbTransactions = _context.Transactions.Where(t => !t.IsPaid).ToList();

            return MapTransactions(dbTransactions);
        }

        public IList<VendorPaidAmountViewModel> GetVendorsPaidAmount(string startDate, string endDate)
        {
            return _context.Transactions
            .Where(t => t.IsPaid && (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate) ? true :
                string.IsNullOrEmpty(startDate) ? t.Date <= Convert.ToDateTime(endDate) :
                    string.IsNullOrEmpty(endDate) ? t.Date >= Convert.ToDateTime(startDate) :
                        t.Date >= Convert.ToDateTime(startDate) && t.Date <= Convert.ToDateTime(endDate)))
            .GroupBy(t => t.VendorId)
            .Select(g => new VendorPaidAmountViewModel
            {
                VendorName = g.Select(v => GetVendors().Where(s => s.Id == v.VendorId).Select(s => s.Name).FirstOrDefault()).FirstOrDefault(),
                TotalSum = g.Sum(v => v.Amount)
            })
            .ToList();
        }

        private IList<Models.Transaction> MapTransactions(IList<Transaction> dbTransactions)
        {
            if (dbTransactions != null && dbTransactions.Any())
            {
                var accounts = GetAccounts();
                var consultants = GetConsultants();
                var projects = GetProjects();
                var vendors = GetVendors();
                var transactions = new List<Models.Transaction>();

                foreach (var dbTransaction in dbTransactions)
                {
                    transactions.Add(new Models.Transaction
                    {
                        Date = dbTransaction.Date.ToShortDateString(),
                        Amount = dbTransaction.Amount,
                        AccountId = dbTransaction.AccountId,
                        AccountName = accounts.Where(a => a.Id == dbTransaction.AccountId).Select(a => a.Name).FirstOrDefault(),
                        ConsultantName = consultants.Where(c => c.Id == dbTransaction.ConsultantId).Select(c => c.Name).FirstOrDefault(),
                        ProjectName = projects.Where(p => p.Id == dbTransaction.ProjectId).Select(p => p.Name).FirstOrDefault(),
                        VendorName = vendors.Where(v => v.Id == dbTransaction.VendorId).Select(v => v.Name).FirstOrDefault()
                    });
                }

                return transactions;
            }

            return null;
        }

        private IList<Models.Account> GetAccounts()
        {
            var dbAccounts = _context.Accounts;

            if (dbAccounts != null && dbAccounts.Any())
            {
                var accounts = new List<Models.Account>();
                foreach (var account in dbAccounts)
                {
                    accounts.Add(new Models.Account
                    {
                        Id = account.Id,
                        Name = account.Name,
                        BankName = account.BankName
                    });
                }

                return accounts;
            }

            return null;
        }

        private IList<Models.Consultant> GetConsultants()
        {
            var dbConsultants = _context.Consultants;

            if (dbConsultants != null && dbConsultants.Any())
            {
                var consultants = new List<Models.Consultant>();
                foreach (var consultant in dbConsultants)
                {
                    consultants.Add(new Models.Consultant
                    {
                        Id = consultant.Id,
                        Name = consultant.Name,
                        Address = consultant.Address,
                        Email = consultant.Email
                    });
                }

                return consultants;
            }

            return null;
        }

        private IList<Project> GetProjects()
        {
            var dbProjects = _context.Projects;

            if (dbProjects != null && dbProjects.Any())
            {
                var projects = new List<Project>();
                foreach (var project in dbProjects)
                {
                    projects.Add(new Project
                    {
                        Id = project.Id,
                        Name = project.Name
                    });
                }

                return projects;
            }

            return null;
        }

        private IList<Models.Vendor> GetVendors()
        {
            var dbVendors = _context.Vendors;

            if (dbVendors != null && dbVendors.Any())
            {
                var vendors = new List<Models.Vendor>();
                foreach (var vendor in dbVendors)
                {
                    vendors.Add(new Models.Vendor
                    {
                        Id = vendor.Id,
                        Name = vendor.Name,
                        Address = vendor.Address
                    });
                }

                return vendors;
            }

            return null;
        }
    }
}
