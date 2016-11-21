namespace MigrationExample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Guid(nullable: false),
                        CustomerNo = c.String(nullable: false, maxLength: 24),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .Index(t => t.CustomerNo, unique: true);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Guid(nullable: false),
                        InvoiceNumber = c.String(nullable: false, maxLength: 24),
                        Customer_CustomerId = c.Guid(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.InvoiceNumber, unique: true)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Guid(nullable: false),
                        Position = c.Short(nullable: false),
                        Text = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_InvoiceId = c.Guid(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.Invoice_InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Invoices", new[] { "InvoiceNumber" });
            DropIndex("dbo.Customers", new[] { "CustomerNo" });
            DropTable("dbo.Items");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
        }
    }
}
