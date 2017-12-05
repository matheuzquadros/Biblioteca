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
    public class ClienteController : Controller
    {

        private ApplicationDbContext _context;

        public ClienteController()
        {
           _context = new ApplicationDbContext();
        }



        // GET: Cliente
        public ActionResult Index()
        {
            var viewModel = _context.Users.ToList();
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
            var user = _context.Users.ToList().Where(c => c.Id == id).SingleOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            else if (User.IsInRole("CanManageCustomers") == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult New()
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            var user = new Cliente();
            return View("Edit", user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cliente user)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);

                userInDb.Nome = user.Nome;
                userInDb.Email = user.Email;
                userInDb.Cpf = user.Cpf;
                userInDb.DataNascimento = user.DataNascimento;
                userInDb.Senha = user.Senha;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();



            return View("Edit", user);
        }

        public ActionResult Remove(int id)
        {
            if(User.IsInRole("CanManageCustomers") == false){
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var user = _context.Users.Single(m => m.Id == id);

            if (user != null) _context.Users.Remove(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}