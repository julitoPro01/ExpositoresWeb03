using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioExpositores" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioExpositores
    {

        // Servicios del CRUD
        [OperationContract]
        List<ExpositorDC> ListarExpositor();

        [OperationContract]
        Boolean ActualizarExpositor(ExpositorDC Expositor);

        [OperationContract]
        Boolean EliminarExpositor(String strCodigo);

        [OperationContract]
        Boolean InsertarExpositor(ExpositorDC Expositor);

        [OperationContract]
        ExpositorDC ConsultarExpositor(string id);

        [OperationContract]
        UbigeoDc ConsultarUbigeo(string id);

    }
    [DataContract]
    [Serializable]
    public class ExpositorDC
    {
        [DataMember]
        public String Id_Expositor { get; set; }

        [DataMember]
        public String Apellido_materno { get; set; }

        [DataMember]
        public String Apellido_paterno { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Dni { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public String Telefono { get; set; }

        [DataMember]
        public String Email { get; set; }

        [DataMember]
        public byte[] Foto_Expositor { get; set; }

        [DataMember]
        public String Comentario { get; set; }

        [DataMember]
        public String Id_Ubigeo { get; set; }

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public DateTime? Fec_Registro { get; set; }

        [DataMember]
        public DateTime? Fec_Ult_Mod { get; set; }

        [DataMember]
        public String Usu_Ult_Mod { get; set; }

        [DataMember]
        public Int32? estado_exp { get; set; }

        [DataMember]
        public String tipo_estado { get; set; }
    }
    [DataContract]
    [Serializable]
    public class UbigeoDc
    {
        [DataMember]
        public string Id_Ubigeo { get; set; }
        [DataMember]
        public string IdDepa { get; set; }
        [DataMember]
        public string IdProv { get; set; }
        [DataMember]
        public string IdDist { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }
    }
}
