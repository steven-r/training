using System.Collections.Generic;
using System.Collections.ObjectModel;
using MigrationExample1.Model;

namespace MigrationExample1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MigrationExample1.Model.InvoiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

protected override void Seed(MigrationExample1.Model.InvoiceContext context)
{
    //  This method will be called after migrating to the latest version.
    context.Customers.AddOrUpdate(x => x.CustomerNo,
        new Customer {CustomerId = Guid.NewGuid(), CustomerNo = "1001", Name = "Test Customer"},
        new Customer { CustomerId = Guid.NewGuid(), CustomerNo = "1002", Name = "Demo Customer"}
        );
    context.SaveChanges();
    Customer c1 = context.Customers.Single(x => x.CustomerNo == "1001");

    context.Invoices.AddOrUpdate(x => x.InvoiceNumber,
        new Invoice { InvoiceId= Guid.NewGuid(), Customer = c1, InvoiceNumber = "INV-15-1001",
            Items = new Collection<Item>
        {
            new Item { ItemId= Guid.NewGuid(), Position = 1, Price = 100.80m, Tax = 0, Text = "Sample Item"},
            new Item { ItemId= Guid.NewGuid(), Position = 2, Price = 1190m, Tax = 119m, Text = "Another Item"}
        } });
    context.SaveChanges();
}
    }
}
