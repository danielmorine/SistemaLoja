using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereceo { get; set; }
        public string Email { get; set; }

        public virtual ICollection<FornecedorProduto>FornecedorProduto { get; set; }
    }
}