using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChangeTrackingExample.Entities
{
    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Key { get; set; }

        [Required, StringLength(128)]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
