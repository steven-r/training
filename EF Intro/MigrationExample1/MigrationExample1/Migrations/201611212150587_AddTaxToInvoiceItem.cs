namespace MigrationExample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaxToInvoiceItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Tax");
        }
    }
}
