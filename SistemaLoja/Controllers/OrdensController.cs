using SistemaLoja.Models;
using SistemaLoja.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLoja.Controllers
{
    public class OrdensController : Controller
    {
        private SistemaLojaContext db = new SistemaLojaContext();
        // GET: Ordens
        public ActionResult NovaOrdem()
        {
            var ordemView = new OrdemView();
            ordemView.Customizar = new Customizar();
            ordemView.Produtos = new List<ProdutoOrdem>();
            Session["ordemView"] = ordemView;

            var list = db.Customizars.ToList();
            //list.Add(new TipoDocumento { TipoDocumentoId = 0, Descricao = "[Selecione o tipo de Documento]" });
            list = list.OrderBy(c => c.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
            return View(ordemView);

        }

        [HttpPost]
        public ActionResult NovaOrdem(OrdemView ordemView)
        {
            var list = db.Customizars.ToList();
            list.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione o tipo de Documento]" });
            list = list.OrderBy(c => c.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(list, "CustomizarId", "NomeCompleto");
            return View(ordemView);

        }

        public ActionResult AddProduto()
        {
            var list = db.Produtoes.ToList();
            list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione o tipo de Documento]" });
            list = list.OrderBy(c => c.Descricao).ToList();
            ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
            return View();

        }

        [HttpPost]
        public ActionResult AddProduto(ProdutoOrdem produtoOrdem)
        {
            var ordemView = Session["ordemView"] as OrdemView;

            var list = db.Produtoes.ToList();
            var produtoId = int.Parse(Request["ProdutoId"]);

            if (produtoId == 0)
            {
                
                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione o tipo de Documento]" });
                list = list.OrderBy(c => c.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "o";

              

                return View(produtoOrdem);

            }

            var produto = db.Produtoes.Find(produtoId);
            if(produto == null)
            {

                list.Add(new ProdutoOrdem { ProdutoId = 0, Descricao = "[Selecione o tipo de Documento]" });
                list = list.OrderBy(c => c.Descricao).ToList();
                ViewBag.ProdutoId = new SelectList(list, "ProdutoId", "Descricao");
                ViewBag.Error = "Erro";

               

                return View(produtoOrdem);


            }
            produtoOrdem = new ProdutoOrdem
            {
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                ProdutoId = produto.ProdutoId,
                Quantidade = float.Parse(Request["Quantidade"]) 
            };

            ordemView.Produtos.Add(produtoOrdem);
            var listC = db.Customizars.ToList();
            listC.Add(new Customizar { CustomizarId = 0, Nome = "[Selecione o tipo de Documento]" });
            listC = listC.OrderBy(c => c.NomeCompleto).ToList();
            ViewBag.CustomizarId = new SelectList(listC, "CustomizarId", "NomeCompleto");


            return View("NovaOrdem", ordemView);


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}