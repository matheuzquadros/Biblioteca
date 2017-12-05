using Biblioteca.Models;
using Biblioteca.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var viewModel = _context.Books.Include("Categoria").ToList();

            if (User.IsInRole("CanManageCustomers"))
            {
                return View(viewModel);
            }
            else
            {
                return View("IndexReadOnly", viewModel);
            }
            
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.ToList().Where(c => c.Id == id).SingleOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            else if (User.IsInRole("CanManageCustomers") == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                book.Categoria = _context.Category.ToList().Where(c => c.Id == book.CategoriaId).SingleOrDefault();
                return View(book);
            }
        }

        public ActionResult New()
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var viewModel = new BookFormViewModel()
            {
                Book = new Book(),
                Categorias = _context.Category.ToList()
            };
            return View("Edit", viewModel);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book) 
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel()
                {
                    Book = book,
                    Categorias = _context.Category.ToList()
                };

                return View("Edit", viewModel);
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
                bookInDb.Categoria = _context.Category.Single(c => c.Id == book.CategoriaId);
                bookInDb.CategoriaId = book.CategoriaId;
                bookInDb.UrlCapa = book.UrlCapa;
                bookInDb.Titulo = book.Titulo;
                bookInDb.Autor = book.Autor;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var book = _context.Books.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel()
            {
                Book = book,
                Categorias = _context.Category.ToList()
            };
            

            return View("Edit", viewModel);
        }

        public ActionResult Remove(int id)
       {
           if(User.IsInRole("CanManageCustomers") == false){
              return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
           }
           var client = _context.Books.Single(m => m.Id == id);

           if (client != null) _context.Books.Remove(client);

           _context.SaveChanges();

           return RedirectToAction("Index");
       }



    }
}