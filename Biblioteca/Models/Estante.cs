using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Estante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Exemplar> Exemplares{ get; set; }
        public int Capacidade { get; set; }


    }
}