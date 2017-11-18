using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaLoja.Models;
using SistemaLoja.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLoja.Controllers
{
    public class UsersController : Controller
    {

        // Criar conexão com DB
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<UserView>();
            
            //percorrer lista
            foreach(var user in users)
            {
                var userView = new UserView
                {
                    //lista de informações
                    Email = user.Email,
                    Nome = user.UserName,
                    UserId = user.Id
                };
                //Armazenas userView que carrega: Email, Nome e Id do usuário
                usersView.Add(userView);
            }
            //retornar na View a lista com a informações
            return View(usersView);
        }
    
    //ABRIR E FECHAR CONEXÃO

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
