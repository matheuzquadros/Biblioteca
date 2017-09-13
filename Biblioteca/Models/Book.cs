using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string UrlCapa { get; set; }
        public string Prefacio { get; set; }
        public int NumeroPaginas { get; set; }
        public string Autor { get; set; }
        public DateTime Lancamento { get; set; }

    }
}