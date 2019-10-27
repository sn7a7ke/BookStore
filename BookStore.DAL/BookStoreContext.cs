using BookStore.DAL.Models;
using System.Data.Entity;

namespace BookStore.DAL
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
