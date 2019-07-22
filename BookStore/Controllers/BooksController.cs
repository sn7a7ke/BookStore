using AutoMapper;
using BookStore.DAL;
using BookStore.DAL.Models;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {        
        private IUnitOfWork unitOfWork;
        private Book _book;

        public BooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Books

        public ActionResult Index()
        {
            var books =
                Mapper.Map<IEnumerable<Book>, List<IndexBookViewModel>>(unitOfWork.Books.GetAll());

            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book =
                Mapper.Map<Book, DetailsBookViewModel>(unitOfWork.Books.Get(id));

            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBookViewModel book)
        {
            try
            {
                _book = Mapper.Map<CreateBookViewModel, Book>(book);

                unitOfWork.Books.Add(_book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(_book);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = Mapper.Map<Book, EditBookViewModel>(unitOfWork.Books.Get(id));
            
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditBookViewModel book)
        {
            try
            {
                _book = Mapper.Map<EditBookViewModel, Book>(book);

                unitOfWork.Books.Update(_book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var book = Mapper.Map<Book, DeleteBookViewModel>(unitOfWork.Books.Get(id));            

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DeleteBookViewModel book)
        {
            try
            {
                _book = Mapper.Map<DeleteBookViewModel, Book>(book);

                unitOfWork.Books.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
