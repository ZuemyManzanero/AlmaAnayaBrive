using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult productolist()
        {
            ML.Producto producto = new ML.Producto();
            producto.Marca = new ML.Marca();
            ML.Result resulmarca = BL.Marca.GetAll();
            ML.Result result = new ML.Result();
            result = BL.Producto.GetAll();
            producto.Marca.Marcas = resulmarca.Objects;
            producto.Productos = result.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultMarca = BL.Marca.GetAll();
            
            if (resultMarca.Correct)
            {
                if (IdProducto == null)
                {
                    producto.Marca = new ML.Marca();
                    producto.Marca.Marcas = resultMarca.Objects;
                    return View(producto);
                }
                else
                {
                    ML.Result result = new ML.Result();
                    result = BL.Producto.GetById(IdProducto.Value);
                    if (result.Correct)
                    {
                        producto = ((ML.Producto)result.Object);

                        producto.Marca.Marcas = resultMarca.Objects;
                        return View(producto);
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if (producto.IdProducto == 0)
            {
                result = BL.Producto.Add(producto);
            }
            else
            {
                result = BL.Producto.Update(producto);
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete (int IdProducto)
        {
            ML.Result result = new ML.Result();
            result = BL.Producto.Delete(IdProducto);
            return PartialView("Modal");
        }
    }
}