namespace MigrationExample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaxToInvoiceItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Tax", c => c.Decimal(nullable: true, precision: 18, scale: 2));
            Sql(@"UPDATE Items 
SET Tax = Price * 0.19, 
    Price = Price / 1.19 
WHERE Price IS NOT NULL");
            Sql(@"UPDATE Items 
SET Tax = 0 
WHERE Price IS NULL");
            AlterColumn("dbo.Items", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Tax");
        }
    }
}
