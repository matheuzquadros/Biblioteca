using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriaController()
        {
           _context = new ApplicationDbContext();
        }

        //
        // GET: /Categoria/
        public ActionResult Index()
        {
            var viewModel = _context.Category.ToList();
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
            var categoria = _context.Category.ToList().Where(c => c.Id == id).SingleOrDefault();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else if (User.IsInRole("CanManageCustomers") == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult New()
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var categoria = new Categoria();
            return View("Edit", categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Categoria categoria)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            if (categoria.Id == 0)
            {
                _context.Category.Add(categoria);
            }
            else
            {
                var categoriaInDb = _context.Category.Single(c => c.Id == categoria.Id);

                categoriaInDb.Nome = categoria.Nome;
                categoriaInDb.Descricao = categoria.Descricao;
               
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var categoria = _context.Category.SingleOrDefault(c => c.Id == id);

            if (categoria == null)
                return HttpNotFound();



            return View("Edit", categoria);
        }

        public ActionResult Remove(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var categoria = _context.Category.Single(m => m.Id == id);

            if (categoria != null) _context.Category.Remove(categoria);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}