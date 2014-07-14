﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using Entities.Abstract;

namespace website.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            return View(repository.Books
                .OrderBy(b => b.Price)
                .Where(b => b.Price < 100)
                .Take(10));
        }

    }
}
