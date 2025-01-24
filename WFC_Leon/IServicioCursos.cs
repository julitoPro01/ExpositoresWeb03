using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioCursos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioCursos
    {
        [OperationContract]
        List<CursosDC> ListarCursos();

        [OperationContract]
        Boolean ActualizarCursos(CursosDC curso);

        [OperationContract]
        Boolean EliminarCurso(String strCodigo);

        [OperationContract]
        Boolean InsertarCurso(CursosDC curso);

        [OperationContract]
        CursosDC ConsultarCurso(string id);

        [OperationContract]
        List<EspecialidadDC> ListarEspecialidad();
    }
    [DataContract]
    [Serializable]
    public class CursosDC
    {
        [DataMember]
        public string cod_curso { get; set; }

        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public int horas_teoria { get; set; }
        [DataMember]
        public int horas_practica { get; set; }
        [DataMember]
        public string nivel_dificultad { get; set; }
        [DataMember]
        public string comentarios { get; set; }
        [DataMember]
        public int IdEspecialidad { get; set; }

        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string usuario_registro { get; set; }
        [DataMember]
        public string usuario_ult_modificacion { get; set; }
        [DataMember]
        public DateTime fecha_ult_modificacion { get; set; }
        [DataMember]
        public int estado_cur { get; set; }

        [DataMember]
        public string estado {  get; set; }
    }

    public class EspecialidadDC
    {
        [DataMember]
        public int IdEspecialidad { get; set; }
        [DataMember]
        public string DescEspecialidad { get; set; }
    }
}
