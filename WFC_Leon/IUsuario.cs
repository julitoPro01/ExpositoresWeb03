using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        UsuarioDc consultarUsuario(String usuario,string contraseña);

        [OperationContract]
        Boolean validarUsuario();
    }
    [DataContract]
    [Serializable]
    public class UsuarioDc
    {
        [DataMember]
        public string Login_Usuario { get; set; }
        [DataMember]
        public string Pass_Usuario { get; set; }
        [DataMember]
        public int Niv_Usuario { get; set; }
        
      
    }
}
