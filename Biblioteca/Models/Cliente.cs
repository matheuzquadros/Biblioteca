using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Cliente 
    {

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

    }
}