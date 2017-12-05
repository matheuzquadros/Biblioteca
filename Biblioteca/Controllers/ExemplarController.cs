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
    public class ExemplarController : Controller
    {
        private ApplicationDbContext _context;

        public ExemplarController()
        {
           _context = new ApplicationDbContext();
        }

        //
        // GET: /Exemplar/
        public ActionResult Index()
        {
            var viewModel = _context.Exemplares.Include("Book").ToList();
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
            var exemplar = _context.Exemplares.Include("Book").ToList().Where(c => c.Id == id).SingleOrDefault();
            if (exemplar == null)
            {
                return HttpNotFound();
            }else if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                return View(exemplar);
            }
        }

        public ActionResult New()
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var viewModel = new ExemplarFormViewModel()
            {
                Exemplar = new Exemplar(),
                Books = _context.Books.ToList()
            };
            return View("Edit", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Exemplar exemplar)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            if (exemplar.Id == 0)
            {
                _context.Exemplares.Add(exemplar);
            }
            else
            {
                var exemplarInDb = _context.Exemplares.Single(c => c.Id == exemplar.Id);

    
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            var exemplar = _context.Exemplares.SingleOrDefault(c => c.Id == id);

            if (exemplar == null)
                return HttpNotFound();

            var viewModel = new ExemplarFormViewModel()
            {
                Exemplar = exemplar,
                Books = _context.Books.ToList()
            };


            return View("Edit", viewModel);
        }

        public ActionResult Remove(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            var exemplar = _context.Exemplares.Single(m => m.Id == id);

            if (exemplar != null) _context.Exemplares.Remove(exemplar);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}