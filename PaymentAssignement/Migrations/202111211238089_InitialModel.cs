namespace PaymentAssignement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Consultant_Id = c.Int(),
                        Project_Id = c.Int(),
                        Vendor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Consultant_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.VendorConsultant",
                c => new
                    {
                        VendorId = c.Int(nullable: false),
                        ConsultantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VendorId, t.ConsultantId })
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("dbo.Consultants", t => t.ConsultantId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.ConsultantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.Transactions", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.VendorConsultant", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.VendorConsultant", "VendorId", "dbo.Vendors");
            DropIndex("dbo.VendorConsultant", new[] { "ConsultantId" });
            DropIndex("dbo.VendorConsultant", new[] { "VendorId" });
            DropIndex("dbo.Transactions", new[] { "Vendor_Id" });
            DropIndex("dbo.Transactions", new[] { "Project_Id" });
            DropIndex("dbo.Transactions", new[] { "Consultant_Id" });
            DropIndex("dbo.Transactions", new[] { "Account_Id" });
            DropTable("dbo.VendorConsultant");
            DropTable("dbo.Transactions");
            DropTable("dbo.Projects");
            DropTable("dbo.Vendors");
            DropTable("dbo.Consultants");
            DropTable("dbo.Accounts");
        }
    }
}
