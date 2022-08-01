using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class SucursalController : Controller
    {
        [HttpGet]
        public ActionResult sucursallist()
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            ML.Result result = new ML.Result();
            result = BL.Sucursal.GetAll();
            sucursal.Sucursales = result.Objects;
            return View(sucursal);
        }
        [HttpGet]
        public ActionResult Form(int? IdSucursal)
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            ML.Result result = new ML.Result();
            if (IdSucursal == null)
            {
                return View(sucursal);
            }
            else
            {
                result = BL.Sucursal.GetById(IdSucursal.Value);
                if (result.Correct)
                {
                    sucursal = ((ML.Sucursal)result.Object);

                    return View(sucursal);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            if(sucursal.IdSucursal == 0)
            {
                result = BL.Sucursal.Add(sucursal);
            }
            else
            {
                result = BL.Sucursal.Update(sucursal);
            }
            return View("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            if(IdSucursal != 0)
            {
                result = BL.Sucursal.Delete(IdSucursal);
            }
            return View("Modal");
        }
    }
}