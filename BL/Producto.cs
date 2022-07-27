using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.ProductogetAll().ToList();
                    result.Objects = new List<object>();
                    foreach(var obj in query)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = obj.IdProducto;
                        producto.Nombre = obj.Nombre;
                        producto.Descripcion = obj.Descripcion;
                        producto.Precio = obj.Precio.Value;
                        producto.Imagen = obj.Imagen;
                        producto.Stock = obj.Stock.Value;
                        producto.Marca = new ML.Marca();
                        producto.Marca.IdMarca = obj.IdMarca.Value;

                        result.Objects.Add(producto);
                    }
                    result.Correct = true;
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock, producto.Marca.IdMarca);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.ProductoGetById(IdProducto);
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Precio = obj.Precio.Value;
                            producto.Stock = obj.Stock.Value;
                            producto.Descripcion = obj.Descripcion;

                            producto.Marca = new ML.Marca();
                            producto.Marca.IdMarca = obj.IdMarca.Value;

                            producto.Imagen = obj.Imagen;

                            result.Object = producto;
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock,  producto.Marca.IdMarca);
                    result.Objects = new List<object>();
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.ProductoDelete(IdProducto);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
