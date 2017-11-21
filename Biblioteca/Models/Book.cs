using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        public Categoria Categoria { get; set; }
        
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
  
        [StringLength(255)]
        [Display(Name = "Imagem da Capa")]
        public string UrlCapa { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Prefácio")]
        public string Prefacio { get; set; }

        [Required]
        [Display(Name = "Número de páginas")]
        public int NumeroPaginas { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
        
        [Required]
        [Display(Name = "Data de lançamento")]
        public DateTime Lancamento { get; set; }

    }
}