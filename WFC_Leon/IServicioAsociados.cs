using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioAsociados" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioAsociados
    {
        [OperationContract]
        List<AsociadosDC> ListarAsociados();

        [OperationContract]
        Boolean ActualizarAsociados(AsociadosDC asociado);

        [OperationContract]
        Boolean EliminarAsociados(String strCodigo);

        [OperationContract]
        Boolean InsertarAsociados(AsociadosDC asociado);

        [OperationContract]
        AsociadosDC ConsultarAsociado(string id);

        [OperationContract]
        List<EmpresasDC> ListarEmpresas();
    }

    [DataContract]
    [Serializable]
    public class AsociadosDC
    {
        [DataMember]
        public string cod_asociado { get; set; }
        [DataMember]
        public string ape_paterno { get; set; }
        [DataMember]
        public string ape_materno { get; set; }
        [DataMember]
        public string nombres { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public DateTime fecha_ingreso { get; set; }
        [DataMember]
        public string dni { get; set; }
        [DataMember]
        public string tlf_domicilio { get; set; }
        [DataMember]
        public string tlf_celular { get; set; }
        [DataMember]
        public string correo { get; set; }
        [DataMember]
        public DateTime fech_ult_capacitacion { get; set; }
        [DataMember]
        public byte[] foto { get; set; }
        [DataMember]
        public Nullable<int> Id_Empresa { get; set; }
        [DataMember]
        public string Id_Ubigeo { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string usuario_ult_modificacion { get; set; }
        [DataMember]
        public DateTime fecha_ult_modificacion { get; set; }
        [DataMember]
        public string usuario_registro { get; set; }
        [DataMember]
        public int estado_aso { get; set; }
        [DataMember]
        public string estado {  get; set; }
    }

    [DataContract]
    [Serializable]
    public class EmpresasDC
    {
        [DataMember]
        public int Id_Empresa { get; set; }
        [DataMember]
        public string Razon_Social { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono1 { get; set; }
        [DataMember]
        public string Telefono2 { get; set; }
        [DataMember]
        public string UrlPagWeb { get; set; }
        [DataMember]
        public string Id_Ubigeo { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string usuario_ult_modificacion { get; set; }
        [DataMember]
        public DateTime fecha_ult_modificacion { get; set; }
        [DataMember]
        public int estado_emp { get; set; }
    }
}
