﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Customizar
    {
        [Key]
        public int CustomizarId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Sobrenome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereceo { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        public int TipoDocumentoId { get; set; }

        public string NomeCompleto { get { return string.Format("{0} {1}", Nome, Sobrenome);} }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Ordem> Ordem { get; set; }

    }
}