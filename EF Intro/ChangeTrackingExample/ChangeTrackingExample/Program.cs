using System.Data.Entity;
using System.Linq;
using ChangeTrackingExample.Entities;

namespace ChangeTrackingExample
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            UpdateData();
            DeleteData();
            AddData();
        }

        private static void AddData()
        {
            using (var db = new ApplicationDbContext())
            {
                Book newBook = new Book {Name = "The Force Awakens", PublishedYear = 2016};
                newBook.Authors.Add(db.Authors.Find(2));
                db.Books.Add(newBook);

                db.SaveChanges();
            }
        }

        private static void DeleteData()
        {
            using (var db = new ApplicationDbContext())
            {
                Book wrongBook = db.Books.SingleOrDefault(x => x.Name == "Harry Potter and the Philosopher's Stone");
                if (wrongBook != null)
                {
                    db.Books.Remove(wrongBook);
                }

                db.SaveChanges();
            }
        }

        private static void UpdateData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Author lucas = db.Authors.Single(x => x.LastName == "Lucas");
                Book book = db.Books.Include(x => x.Authors).Single(x => x.Name.StartsWith("Episode IV"));
                book.Authors.Add(lucas);

                book = db.Books.Single(x => x.Name.StartsWith("Episode V ")); // the space after 'V' is important!
                book.PublishedYear = 1980;
                db.SaveChanges();
            }
        }
    }
}
