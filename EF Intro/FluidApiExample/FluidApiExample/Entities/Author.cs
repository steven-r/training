using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Entities
{
    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        public int Key { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Book Book { get; set; }
    }
}
