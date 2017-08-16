using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Unidade
    {
        private int id { get; set; }
        private string cep { get; set; }
        private IList <Estante> estantes { get; set; }
        private string estado { get; set; }
        private string cidade { get; set; }

    }
}