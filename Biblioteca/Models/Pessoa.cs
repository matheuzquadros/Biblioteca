using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public abstract class Pessoa
    {
        private int id { get; set; }
        private string nome{ get; set; }
        private string cpf{ get; set; }
        private DateTime dataNascimento{ get; set; }
        private string senha { get; set; }


    }
}