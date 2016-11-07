using System;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Entities
{
    public class Book
    {
        public int Key { get; set; }

        public string Name { get; set; }

        public DateTime Published { get; set; }
    }
}