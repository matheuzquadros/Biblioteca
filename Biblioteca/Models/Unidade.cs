using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public IList <Estante> Estantes { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

    }
}