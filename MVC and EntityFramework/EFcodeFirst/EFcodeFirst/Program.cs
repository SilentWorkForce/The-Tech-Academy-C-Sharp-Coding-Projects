/*Using Entity Framework*/
/*C# and .NET final*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookmarkContext())
            {
                var bookmark1 = new Bookmark(1, "www.google.com", "e:/Marks");
                var bookmark2 = new Bookmark(2, "www.facebook.com", "e:/Marks");

                db.bookmarks.Add(bookmark1);
                db.bookmarks.Add(bookmark2);
                db.SaveChanges();


                // Display all Bookmarks and librarys in the database
                var query = from b in db.bookmarks
                            select b.SiteURL;

                Console.WriteLine("All Bookmarks in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class BookmarkLibrary
    {
        public BookmarkLibrary()
        {

        }
        public BookmarkLibrary(int id)
        {
            this.UserId = id;
        }

        [Key]public int UserId { get; set; }
        public List<Bookmark> bookmarks { get; set; }
    }

    public class Bookmark
    {
        public Bookmark()
        {

        }
        public Bookmark(int id, string url, string loc)
        {
            this.Id = id;
            this.SiteURL = url;
            this.FileLoc = loc;
        }
        [Key]public int Id { get; set; }
        public string SiteURL { get; set; }
        public string FileLoc { get; set; }

    }

    public class BookmarkContext : DbContext
    {
        public DbSet<BookmarkLibrary> libraries { get; set; }
        public DbSet<Bookmark> bookmarks { get; set; }
    }
}