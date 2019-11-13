using System;
using BookStore.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BookStore.DAL;
using Moq;
using BookStore.DAL.Models;
using System.Collections.Generic;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories;
using BookStore.Models;
using AutoMapper;

namespace BookStore.Tests
{
    [TestClass]
    public class BooksControllerTest
    {
        private BooksController _controller;
        private ViewResult _result;
        private IRepository<Book> _bookRepository;

        [TestInitialize]
        public void SetupContext()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MappingProfile()));
            _bookRepository = BookRepository.GetInstance();
            var _mockUoW = new Mock<IUnitOfWork>();
            _mockUoW.Setup(a => a.Books).Returns(_bookRepository);
            _controller = new BooksController(_mockUoW.Object);
        }

        [TestCleanup]
        public void ClearContext()
        {
            _controller.Dispose();
        }

        [TestMethod]
        public void Index()
        {
            _result = _controller.Index() as ViewResult;

            Assert.IsNotNull(_result);
            //Assert.AreEqual("Index", _result.ViewBag.Title);
            Assert.IsInstanceOfType(_result.Model, typeof(List<IndexBookViewModel>));
        }
    }
}
