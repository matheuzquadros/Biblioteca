using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Livro
    {
        private int id { get; set; }
        private string isbn { get; set; }
        private int numeroPaginas { get; set; }
        private string autor { get; set; }
        private DateTime lancamento { get; set; }

    }
}