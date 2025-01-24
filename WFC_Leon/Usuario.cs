using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuario" en el código y en el archivo de configuración a la vez.
    public class Usuario : IUsuario
    {
        public UsuarioDc consultarUsuario(string usuario,string contraseña)
        {
            try
            {
                using (var leonDb = new LeonComputingEntities9())
                {
                    var query = leonDb.Tb_Usuario.Where(usu=>
                    usu.Login_Usuario == usuario &&
                    usu.Pass_Usuario == contraseña
                    && usu.Est_Usuario != 0).FirstOrDefault();
                    if (query != null)
                    {
                        return new UsuarioDc
                        {
                            Login_Usuario=query.Login_Usuario,
                            Niv_Usuario=Convert.ToInt16( query.Niv_Usuario),
                            Pass_Usuario=query.Pass_Usuario
                        };
                    }

                    return null;
                }

            }catch (Exception ex)
            {
                throw new Exception( ex.Message,ex );
            }
        }

        public bool validarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
