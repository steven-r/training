/*****************
* This abstract class need for creating derived Entities 
* Example class ProductEntity : BaseEntity
*
*****************/
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.CodeFirst.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid InternalId { get; set; }
    }
}
