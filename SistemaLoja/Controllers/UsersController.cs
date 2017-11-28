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

        public ActionResult AddRole (string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            //fará a verificação se o id é o mesmo que tem no id
            var user = users.Find(u => u.Id == userId);
            var userView = new UserView
            {
               
                //lista de informações
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
             };


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Selecione uma permissão]" });
            list = list.OrderBy(c => c.Name).ToList();
            ViewBag.RoleId = new SelectList(list, "Id", "Name");

            return View(userView);

        }

        [HttpPost]
        public ActionResult AddRole (string userId)
        {

        }
    
        public ActionResult Roles(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();

           //fará a verificação se o id é o mesmo que tem no id
            var user = users.Find(u => u.Id == userId);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleView>();



            foreach ( var item in user.Roles )
            {
                var role = roles.Find(r => r.Id == item. RoleId);
                var roleView = new RoleView
                {
                    RoleId = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }


       

            var userView = new UserView
            {
                //lista de informações
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
                Roles = rolesView
                };
            return View(userView);

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
