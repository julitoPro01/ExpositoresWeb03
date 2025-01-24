using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioConsultaInscripcionEvento" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioConsultaInscripcionEvento
    {
        [OperationContract]

        List<EventosDc> consultarEventos(
            string  lugar,
            string turno,
            string expositor,
            int empresa,
            string codAsociado,
            string apeAsociado,
            DateTime fechaInicio,
            DateTime fechaFin,
            int estado
            );
    }

    [DataContract]
    [Serializable]
    public class EventosDc
    {
        [DataMember]
        public int id_evento { get; set; }
        [DataMember]
        public string Empresa { get; set; }
        [DataMember]
        public string cod_asociado { get; set; }
        [DataMember]
        public string Expositor { get; set; }
        [DataMember]
        public string Asociado { get; set; }
        [DataMember]
        public string Evento { get; set; }
        [DataMember]
        public DateTime fecha_inicio { get; set; }
        [DataMember]
        public DateTime fecha_fin { get; set; }

        [DataMember]
        public string Turno { get; set; }
        [DataMember]
        public string Lugar { get; set; }
        [DataMember]
        public string estado_eve { get; set; } 
    }
}
