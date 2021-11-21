namespace PaymentAssignement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Transactions", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.Transactions", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "Vendor_Id", "dbo.Vendors");
            DropIndex("dbo.Transactions", new[] { "Account_Id" });
            DropIndex("dbo.Transactions", new[] { "Consultant_Id" });
            DropIndex("dbo.Transactions", new[] { "Project_Id" });
            DropIndex("dbo.Transactions", new[] { "Vendor_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Account_Id", newName: "AccountId");
            RenameColumn(table: "dbo.Transactions", name: "Consultant_Id", newName: "ConsultantId");
            RenameColumn(table: "dbo.Transactions", name: "Project_Id", newName: "ProjectId");
            RenameColumn(table: "dbo.Transactions", name: "Vendor_Id", newName: "VendorId");
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ConsultantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "AccountId");
            CreateIndex("dbo.Transactions", "ConsultantId");
            CreateIndex("dbo.Transactions", "VendorId");
            CreateIndex("dbo.Transactions", "ProjectId");
            AddForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "ConsultantId", "dbo.Consultants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Transactions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "ProjectId" });
            DropIndex("dbo.Transactions", new[] { "VendorId" });
            DropIndex("dbo.Transactions", new[] { "ConsultantId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            AlterColumn("dbo.Transactions", "VendorId", c => c.Int());
            AlterColumn("dbo.Transactions", "ProjectId", c => c.Int());
            AlterColumn("dbo.Transactions", "ConsultantId", c => c.Int());
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "VendorId", newName: "Vendor_Id");
            RenameColumn(table: "dbo.Transactions", name: "ProjectId", newName: "Project_Id");
            RenameColumn(table: "dbo.Transactions", name: "ConsultantId", newName: "Consultant_Id");
            RenameColumn(table: "dbo.Transactions", name: "AccountId", newName: "Account_Id");
            CreateIndex("dbo.Transactions", "Vendor_Id");
            CreateIndex("dbo.Transactions", "Project_Id");
            CreateIndex("dbo.Transactions", "Consultant_Id");
            CreateIndex("dbo.Transactions", "Account_Id");
            AddForeignKey("dbo.Transactions", "Vendor_Id", "dbo.Vendors", "Id");
            AddForeignKey("dbo.Transactions", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Transactions", "Consultant_Id", "dbo.Consultants", "Id");
            AddForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts", "Id");
        }
    }
}
