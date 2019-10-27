using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;

namespace BookStore.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
    }
}