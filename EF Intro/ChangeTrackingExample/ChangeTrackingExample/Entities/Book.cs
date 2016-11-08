using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChangeTrackingExample.Entities
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        [Key]
        public int Key { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int PublishedYear { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}