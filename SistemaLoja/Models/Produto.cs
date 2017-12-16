using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
       // [DisplayFormat(DataFormatString = "{0,C2}", ApplyFormatInEditMode = false)]
        public decimal Preco { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        //[DisplayFormat(DataFormatString = "{0,N2}", ApplyFormatInEditMode = false)]
        public float Estoque { get; set; }

        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Descricao { get; set; }

      //  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
       // [DataType(DataType.Date)]
        [Display(Name = "Ultima compra")]
        public DateTime UltimaCompra { get; set; }

        [Display(Name = "Comentario")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }


        //sempre que tiver uma propriedade virtual, será necessário inserir um JsonIgnore
        [JsonIgnore]
        public virtual ICollection<FornecedorProduto> FornecedorProduto { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrdemDetalhe> OrdensDetalhes { get; set; }

    }
}