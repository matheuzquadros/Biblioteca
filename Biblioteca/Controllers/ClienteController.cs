using Biblioteca.Models;
using Biblioteca.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class ClienteController : Controller
    {
        public List<Cliente> Clientes =  new List<Cliente>
                {
                    new Cliente {Id = 1,  Nome = "Matheus de Quadros", Senha="Matheus123", Cpf="123"},
                    new Cliente {Id = 2,  Nome = "Candido portinari", Senha="senha123", Cpf="1234"},
                    new Cliente {Id = 3,  Nome = "Tobias", Senha="onca123", Cpf="74842"},
                    new Cliente {Id = 4,  Nome = "Ariana", Senha="everyday", Cpf="5252"}
            
                };

        // GET: Cliente
        public ActionResult Index()
        {
            var viewModel = new ClienteIndexViewModel
            {
                Clientes = Clientes
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (Clientes.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Clientes[id - 1];

            return View(cliente);
        }
    }
}