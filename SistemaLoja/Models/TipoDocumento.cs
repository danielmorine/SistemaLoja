﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }
        [Display(Name = "Tipo de Documento")]
        

        public string Descricao { get; set; }

        public virtual ICollection<Funcionario>Funcionarios { get; set; }

    }
}