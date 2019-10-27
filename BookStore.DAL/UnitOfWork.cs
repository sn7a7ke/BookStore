using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;
        private IRepository<Book> _bookRepository;

        public UnitOfWork(DbContext db)
        {
            _db = db;
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

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
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