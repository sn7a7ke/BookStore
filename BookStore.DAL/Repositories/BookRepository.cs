using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private static readonly BookRepository instance = new BookRepository();        

        public static BookRepository GetInstance()
        {
            return instance;
        }

        private BookRepository()
        {
            Books = new List<Book>();

            Book b1 = new Book() { Id = 1, Title = "Title1", Authors = "Author1", Tag = "Tag1", CreateDate = DateTime.Now };
            Books.Add(b1);

            Book b2 = new Book() { Id = 2, Title = "Title2", Authors = "Author2", Tag = "Tag2", CreateDate = DateTime.Now };
            Books.Add(b2);

            MaxId = 2;
        }

        private List<Book> Books { get; set; }
        private int MaxId { get; set ; }

        public IEnumerable<Book> GetAll()
        {            
            return Books;
        }

        public Book Get(int id)
        {
            var entry = Books.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new ArgumentOutOfRangeException("No such book");
            return entry;
        }

        public Book Add(Book entity)
        {
            MaxId++;
            entity.Id = MaxId;
            entity.CreateDate = DateTime.Now;
            Books.Add(entity);
            return entity;
        }
        
        public Book Update(Book entity)
        {
            var entry = Books.FirstOrDefault(e => e.Id == entity.Id);
            if (entry == null)
                throw new ArgumentOutOfRangeException("No such book");
            MapThem(entry, entity);
            return entry;
        }

        private void MapThem(Book source, Book change)
        {
            source.Title = change.Title;
            source.Authors = change.Authors;
            source.Tag = change.Tag;            
        }

        public void Delete(int id)
        {
            var entry = Books.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new ArgumentOutOfRangeException("No such book");
            Books.Remove(entry);
        }        
    }
}