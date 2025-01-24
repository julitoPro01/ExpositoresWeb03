using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioConsultaInscripcionEvento" en el código y en el archivo de configuración a la vez.
    public class ServicioConsultaInscripcionEvento : IServicioConsultaInscripcionEvento
    {
        public List<EventosDc> consultarEventos(string lugar, string turno, string expositor, int empresa, 
            string codAsociado, string apeAsociado, DateTime fechaInicio, DateTime fechaFin,int estado)
        {

            using ( LeonComputingEntities9 contextDb = new LeonComputingEntities9())
            {
                try
                {
                    var query = contextDb.usp_consultarAsociadosInscritos(
                        lugar, turno, expositor, empresa, codAsociado, apeAsociado,fechaInicio,fechaFin,
                        estado
                        );

                if ( query != null )
                    {
                        List<EventosDc> eventos = new List<EventosDc>();    

                        foreach ( var e in query)
                        {
                            var obj = new EventosDc
                            {
                                id_evento = e.id_evento,
                                Empresa = e.Empresa,
                                cod_asociado = e.cod_asociado,
                                Expositor = e.Expositor,
                                Asociado = e.Asociado,
                                Evento = e.Evento,
                                fecha_inicio = Convert.ToDateTime(e.fecha_inicio),
                                fecha_fin = Convert.ToDateTime(e.fecha_fin),
                                Turno = e.Turno,
                                Lugar = e.Lugar,
                               
                            };
                            if (e.estado_eve == 0)
                                obj.estado_eve = "Inactivo";
                            else
                                obj.estado_eve = "Activo";
                            
                            eventos.Add(obj);
                           
                        }
                            return eventos;
                    }
                   else {
                        return null;
                    }

                }catch (Exception ex)
                {
                    throw new Exception(ex.Message,ex);
                }
            }
            
        }

    }
}
