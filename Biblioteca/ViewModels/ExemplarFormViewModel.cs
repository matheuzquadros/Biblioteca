using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.ViewModels
{
    public class ExemplarFormViewModel
    {

        public Exemplar Exemplar { get; set; }

        public List<Book> Books { get; set; }
    }
}