using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetByUserName(usuario);

            if (result.Correct)
            {
                ML.Usuario resulusuario = new ML.Usuario();
                resulusuario = (ML.Usuario)result.Object;
                if (usuario.UserName == resulusuario.UserName && usuario.Password == resulusuario.Password)
                {
                    return RedirectToAction("Index", "Template");
                }
                else
                {
                    ViewBag.Mensaje = "Error en los datos introducidos...";
                }
            }
            else
            {
                ViewBag.Mensaje = "No se encuentra el usuario en los registros";
            }

            return View("Index", "Template");

        }
    }
}