﻿using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
           _context = new ApplicationDbContext();
        }

        // GET: Book
        public ActionResult Index()
        {
            var viewModel =  _context.Books.ToList();
            
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.ToList().Where(c => c.Id == id).SingleOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }else
            {
                return View(book);
            }
        }

        public ActionResult New()
        {
            var book = new Book();
            return View("Edit", book);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book) 
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);

                bookInDb.Isbn = book.Isbn;
                bookInDb.Lancamento = book.Lancamento;
                bookInDb.NumeroPaginas = book.NumeroPaginas;
                bookInDb.Prefacio = book.Prefacio;
                bookInDb.UrlCapa = book.UrlCapa;
                bookInDb.Titulo = book.Titulo;
                bookInDb.Autor = book.Autor;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Books.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            

            return View("Edit", customer);
        }

        public ActionResult Remove(int id)
       {
           var client = _context.Books.Single(m => m.Id == id);

           if (client != null) _context.Books.Remove(client);

           _context.SaveChanges();

           return RedirectToAction("Index");
       }



    }
}