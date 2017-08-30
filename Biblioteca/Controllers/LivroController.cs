using Biblioteca.Models;
using Biblioteca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        public List<Livro> Livros = new List<Livro>
        {
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 3, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 4, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 5, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 6, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 7, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 8, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 9, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 10, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 11, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 12, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 13, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 14, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"}
        };


        // GET: Livro
        public ActionResult Index()
        {
            var viewModel = new LivroIndexViewModel
            {
                Livros = Livros
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var livro = Livros.Where(c => c.Id == id).SingleOrDefault();
            if (livro == null)
            {
                return HttpNotFound();
            }else
            {
                return View(livro);
            }
        }
    }
}