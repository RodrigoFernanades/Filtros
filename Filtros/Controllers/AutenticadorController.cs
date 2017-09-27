using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Filtros.Models;

namespace Filtros.Controllers
{
    public class AutenticadorController : Controller
    {
        // GET: Autenticador
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            bool resultado = FormsAuthentication.Authenticate(usuario.Username, usuario.Password);
            if (resultado)
            {

                FormsAuthentication.SetAuthCookie(usuario.Username, false);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                ViewBag.Mensagem = "Usuário ou Senha incorreto";
                return View(usuario);
            }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logar");
        }
    }
}