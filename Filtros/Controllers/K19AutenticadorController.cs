using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtros.Models;

namespace Filtros.Controllers
{
    public class K19AutenticadorController : Controller
    {
        // GET: K19Autenticador
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            if(usuario.Username.EndsWith("@k19.com.br") && usuario.Password == "32")
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
        }
    }
}