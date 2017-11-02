using SistemaLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaLoja.Context
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto>Produto { get; set; }

    }
}