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
        public LivroIndexViewModel livroViewModel = new LivroIndexViewModel();

        
        // GET: Livro
        public ActionResult Index()
        {
        livroViewModel.Livros = new List<Livro>
        {
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"},
            new Livro {Id = 1, NumeroPaginas= 312, Titulo = "Bilhões e Bilhões", Autor="Carl Sagan", UrlCapa="bilhoesbilhoes.jpg"},
            new Livro {Id = 2, NumeroPaginas= 521, Titulo = "As cronicas de arthur", Autor="Bernard cornwell", UrlCapa="reiDoInverno.jpg"}
        };

            return View(livroViewModel);
        }
    }
}