using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _dbContext;
        private BookRepository bookRepository;

        public UnitOfWork(DbContext db)
        {
            _dbContext = db ?? throw new ArgumentNullException(nameof(db));
        }

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = BookRepository.GetInstance();
                return bookRepository;
            }
        }
        
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Reject()
        {
            // https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
            foreach (var entry in _dbContext.ChangeTracker.Entries()
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

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}