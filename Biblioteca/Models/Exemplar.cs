using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Exemplar
    {
        public int Id { get; set; }

        public Book Book {get; set;}


        [Display(Name = "Livro")]

        public int BookId { get; set; }

    }
}