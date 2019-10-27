using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories;
using System;
using System.Data.Entity;
using System.Linq;

namespace BookStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _db;
        private IRepository<Book> _bookRepository;

        public UnitOfWork(BookStoreContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = BookRepository.GetInstance();
                return _bookRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Reject()
        {
            foreach (var entry in _db.ChangeTracker.Entries()
                          .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _db.Dispose();
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}