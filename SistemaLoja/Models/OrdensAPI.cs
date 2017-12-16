using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class OrdensAPI
    {
        [Key]
        public int OrdensId { get; set; }
        public DateTime OrdemData { get; set; }
        //trazer a coleção de itens da Customizar com o nome de customizar.
        public Customizar customizar { get; set; }

        public OrdemStatus OrdemStatus { get; set; }

        public ICollection<OrdemDetalhe>Detalhes { get; set; }
    }
}