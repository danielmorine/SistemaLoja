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
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public decimal Salario { get; set; }
        public float Comissao { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime Cadastro { get; set; }
        public string Email { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}