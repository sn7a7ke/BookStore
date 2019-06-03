using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class UnitOfWork //: IDisposable
    {        
        //private DbContext db;
        private BookRepository bookRepository;        

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = BookRepository.GetInstance();
                return bookRepository;
            }
        }
                

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}