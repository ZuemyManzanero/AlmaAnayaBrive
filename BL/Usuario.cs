using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetByUserName(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.BriveEntities context = new DL.BriveEntities())
                {
                    var query = context.UsuarioGetByUserName(usuario.UserName);
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;

                            result.Object = usuario;
                            result.Correct = true;
                        }
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
