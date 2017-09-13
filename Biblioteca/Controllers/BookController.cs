using Biblioteca.Models;
using Biblioteca.ViewModel;
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
            var viewModel = new BookIndexViewModel
            {
                Books =  _context.Books.ToList()
            };
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
    }
}