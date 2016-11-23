using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationExample1.Model
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }

        [Required, StringLength(24), Index(IsUnique = true)]
        public string InvoiceNumber { get; set; }

        public Customer Customer { get; set; }

        public Collection<Item> Items { get; set; }
    }

    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }

        public short Position { get; set; }

        public string Text { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }
    }

    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required, StringLength(24), Index(IsUnique = true)]
        public string CustomerNo { get; set; }

        public string Name { get; set; }
    }
}
