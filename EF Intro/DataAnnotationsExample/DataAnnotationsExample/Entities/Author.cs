using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Entities
{
    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        [Key]
        public int Key { get; set; }

        [Required, StringLength(128)]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }

        public Book Book { get; set; }
    }
}
