using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Categoria
    {
        public int Id {get; set;}

        [Required]
        [StringLength(70)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}