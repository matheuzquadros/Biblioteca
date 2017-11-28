using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }

        public List<Categoria> Categorias { get; set; }
    }
}