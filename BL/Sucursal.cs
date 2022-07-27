using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.SucursalGetAll().ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Sucursal sucursal = new ML.Sucursal();
                            sucursal.IdSucursal = obj.IdSucursal;
                            sucursal.Nombre = obj.Nombre;
                            sucursal.Ubicacion = obj.Ubicacion;
                            sucursal.Telefono = obj.Telefeono;
                            result.Objects.Add(sucursal);
                        }
                        result.Correct = true;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.SucursalAdd(sucursal.Nombre, sucursal.Ubicacion, sucursal.Telefono);
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
        public static ML.Result GetById(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.SucursalGetById(IdSucursal);
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Sucursal sucursal = new ML.Sucursal();

                            sucursal.IdSucursal = obj.IdSucursal;
                            sucursal.Nombre = obj.Nombre;
                            sucursal.Ubicacion = obj.Ubicacion;
                            sucursal.Telefono = obj.Telefeono;

                            result.Object = sucursal;
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
        public static ML.Result Update(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.SucursalUpdate(sucursal.IdSucursal, sucursal.Nombre, sucursal.Ubicacion, sucursal.Telefono);
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
        public static ML.Result Delete(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.SucursalDelete(IdSucursal);
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
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
