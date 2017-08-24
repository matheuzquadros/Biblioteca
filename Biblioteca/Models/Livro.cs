using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public int NumeroPaginas { get; set; }
        public string Autor { get; set; }
        public DateTime Lancamento { get; set; }

    }
}