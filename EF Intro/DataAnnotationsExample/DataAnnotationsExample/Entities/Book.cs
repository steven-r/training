using System;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Entities
{
    public class Book
    {
        [Key]
        public int Key { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public DateTime Published { get; set; }
    }
}