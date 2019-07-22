using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;

namespace BookStore.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
    }
}