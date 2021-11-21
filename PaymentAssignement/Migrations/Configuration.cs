namespace PaymentAssignement.Migrations
{
    using PaymentAssignement.Context.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.PaymentAssignmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.PaymentAssignmentContext context)
        {
            #region Add Vendors and Consultants

            var vendor1 = new Vendor { Id = 1, Name = "Vendor 1", Address = "North St 1", Consultants = new List<Consultant>() };
            var vendor2 = new Vendor { Id = 2, Name = "Vendor 2", Address = "North St 2", Consultants = new List<Consultant>() };
            var vendor3 = new Vendor { Id = 3, Name = "Vendor 3", Address = "North St 3", Consultants = new List<Consultant>() };
            var vendor4 = new Vendor { Id = 4, Name = "Vendor 4", Address = "North St 4", Consultants = new List<Consultant>() };
            var vendor5 = new Vendor { Id = 5, Name = "Vendor 5", Address = "North St 5", Consultants = new List<Consultant>() };

            var consultant1 = new Consultant { Id = 1, Name = "Consultant 1", Address = "Address 1", Email = "consultant1@test.com", Vendors = new List<Vendor>() };
            var consultant2 = new Consultant { Id = 2, Name = "Consultant 2", Address = "Address 2", Email = "consultant2@test.com", Vendors = new List<Vendor>() };
            var consultant3 = new Consultant { Id = 3, Name = "Consultant 3", Address = "Address 3", Email = "consultant3@test.com", Vendors = new List<Vendor>() };
            var consultant4 = new Consultant { Id = 4, Name = "Consultant 4", Address = "Address 4", Email = "consultant4@test.com", Vendors = new List<Vendor>() };
            var consultant5 = new Consultant { Id = 5, Name = "Consultant 5", Address = "Address 5", Email = "consultant5@test.com", Vendors = new List<Vendor>() };

            vendor1.Consultants.Add(consultant1);
            vendor1.Consultants.Add(consultant2);
            vendor1.Consultants.Add(consultant3);
            vendor2.Consultants.Add(consultant2);
            vendor3.Consultants.Add(consultant3);
            vendor4.Consultants.Add(consultant4);
            vendor5.Consultants.Add(consultant4);
            vendor5.Consultants.Add(consultant5);

            consultant1.Vendors.Add(vendor1);
            consultant2.Vendors.Add(vendor1);
            consultant2.Vendors.Add(vendor2);
            consultant3.Vendors.Add(vendor1);
            consultant3.Vendors.Add(vendor3);
            consultant4.Vendors.Add(vendor4);
            consultant4.Vendors.Add(vendor5);
            consultant5.Vendors.Add(vendor5);

            context.Vendors.AddOrUpdate(v => v.Id, vendor1, vendor2, vendor3, vendor4, vendor5);
            context.Consultants.AddOrUpdate(c => c.Id, consultant1, consultant2, consultant3, consultant4, consultant5);
            #endregion


            #region Add Projects

            var project1 = new Project { Id = 1, Name = "Project 1" };
            var project2 = new Project { Id = 2, Name = "Project 2" };
            var project3 = new Project { Id = 3, Name = "Project 3" };
            var project4 = new Project { Id = 4, Name = "Project 4" };
            var project5 = new Project { Id = 5, Name = "Project 5" };

            context.Projects.AddOrUpdate(p => p.Id, project1, project2, project3, project4, project5);
            #endregion


            #region Add Accounts

            var account1 = new Account { Id = 1, Name = "Jane Doe", Number = "123456789", BankName = "Bank of America" };
            var account2 = new Account { Id = 2, Name = "John Doe", Number = "987654321", BankName = "Bank of America" };
            var account3 = new Account { Id = 3, Name = "Jane Smith", Number = "123654789", BankName = "Bank of America" };
            var account4 = new Account { Id = 4, Name = "John Smith", Number = "111222333", BankName = "US Bank" };
            var account5 = new Account { Id = 5, Name = "Alessandra Collins", Number = "111333222", BankName = "US Bank" };
            var account6 = new Account { Id = 6, Name = "Philip Hayes", Number = "333222111", BankName = "US Bank" };
            var account7 = new Account { Id = 7, Name = "Liam Lee", Number = "444555666", BankName = "JPMorgan Chase & Co." };
            var account8 = new Account { Id = 8, Name = "Laurence O'Brien", Number = "666555444", BankName = "JPMorgan Chase & Co." };
            var account9 = new Account { Id = 9, Name = "Michael O'Reilly", Number = "444666555", BankName = "JPMorgan Chase & Co." };

            context.Accounts.AddOrUpdate(a => a.Id, account1, account2, account3, account4, account5, account6, account7, account8, account9);
            #endregion


            #region Add Transactions

            var transaction1 = new Transaction
            {
                Id = 1,
                Date = new DateTime(2021, 6, 7),
                Amount = 189.00m,
                Account = account1,
                Consultant = consultant1,
                IsPaid = false,
                Project = project1,
                Vendor = vendor1
            };

            var transaction2 = new Transaction
            {
                Id = 2,
                Date = new DateTime(2021, 8, 8),
                Amount = 19.99m,
                Account = account2,
                Consultant = consultant1,
                IsPaid = true,
                Project = project2,
                Vendor = vendor2
            };

            var transaction3 = new Transaction
            {
                Id = 3,
                Date = new DateTime(2021, 9, 9),
                Amount = 256.49m,
                Account = account3,
                Consultant = consultant2,
                IsPaid = true,
                Project = project3,
                Vendor = vendor2
            };

            var transaction4 = new Transaction
            {
                Id = 4,
                Date = new DateTime(2021, 10, 10),
                Amount = 112.56m,
                Account = account4,
                Consultant = consultant1,
                IsPaid = true,
                Project = project4,
                Vendor = vendor1
            };

            var transaction5 = new Transaction
            {
                Id = 4,
                Date = new DateTime(2021, 6, 6),
                Amount = 38.91m,
                Account = account5,
                Consultant = consultant3,
                IsPaid = false,
                Project = project5,
                Vendor = vendor3
            };

            var transaction6 = new Transaction
            {
                Id = 6,
                Date = new DateTime(2021, 5, 5),
                Amount = 374,
                Account = account5,
                Consultant = consultant4,
                IsPaid = false,
                Project = project5,
                Vendor = vendor4
            };

            var transaction7 = new Transaction
            {
                Id = 7,
                Date = new DateTime(2021, 4, 4),
                Amount = 38.91m,
                Account = account5,
                Consultant = consultant5,
                IsPaid = false,
                Project = project5,
                Vendor = vendor4
            };

            context.Transactions.AddOrUpdate(t => t.Id, transaction1, transaction2, transaction3, transaction4, transaction5, transaction6, transaction7);
            #endregion
        }
    }
}
