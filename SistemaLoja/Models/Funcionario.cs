using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Display(Name = "Primeiro nome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [StringLength(30, ErrorMessage = "insira um nome")]
        public string Nome { get; set; }

        [Display(Name = "Primeiro Sobrenome")]
        public string SobreNome { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DisplayFormat(DataFormatString = "{0,C2}", ApplyFormatInEditMode = false)]
        public decimal Salario { get; set; }

        [DisplayFormat(DataFormatString = "{0,P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Comissão")]
        public float Comissao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Data de cadastro")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Cadastro { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string TipoDocumentoId { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}