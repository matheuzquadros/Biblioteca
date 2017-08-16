using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Estante
    {
        private int id { get; set; }
        private string nome { get; set; }
        private IList<Exemplar> exemplares{ get; set; }
        private int capacidade { get; set; }


    }
}