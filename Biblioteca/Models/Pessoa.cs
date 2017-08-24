using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Cpf{ get; set; }
        public DateTime DataNascimento{ get; set; }
        public string Senha { get; set; }


    }
}