using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVC_Consultas.ServiceReferenceAsociado;
using MVC_Consultas.ServiceReferenceEventos;
using MVC_Consultas.ServiceReferenceExpositores;

namespace MVC_Consultas.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index()
        {
            var evento =new EventosViewModel();

            evento.Expositor = listarExpositor();
            
            if (evento.Expositor == null || !evento.Expositor.Any())
            {
                evento.ErrorExpositor = "No se encontraron Expositores o ocurrió un error.";

            }

            evento.Empresa = listarEmpresa();

            if (evento.Empresa == null || !evento.Empresa.Any())
            {
                evento.ErrorEmpresa = "No se encontraron Empresas o ocurrió un error.";

            }

            evento.Asociado = listarAsociado();

            if (evento.Asociado == null || !evento.Asociado.Any())
            {
                evento.ErrorAsociado = "No se encontraron Asociados o ocurrió un error.";

            }

            evento.Eventos = listarEventos("","","","0","","","","","1");
            if (evento.Eventos == null || !evento.Eventos.Any())
            {
               evento.ErrorMessage = "No se encontraron eventos o ocurrió un error.";
            }


            
            return View(evento);
        }

        private IEnumerable<AsociadosDC> listarAsociado()
        {

            using (var leonDb = new ServicioAsociadosClient())
            {
                try
                {
                    return leonDb.ListarAsociados();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private IEnumerable<EmpresasDC> listarEmpresa()
        {

            using (var leonDb = new ServicioAsociadosClient())
            {
                try
                {
                    return leonDb.ListarEmpresas();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        private IEnumerable<ExpositorDC> listarExpositor()
        {
            using(var leonDb = new ServicioExpositoresClient())
            {
                try
                {
                    return leonDb.ListarExpositor();

                }catch (Exception ex)
                {
                      return null;
                }
            }
        }
        private IEnumerable<EventosDc> listarEventos(string lugar,string turno,string expositor,
            string empresa,string asociado,string ape_aso,string fecha_inicio,string fecha_fin, string estado)
        {
            using (var leonDb = new ServicioConsultaInscripcionEventoClient())
            {
                try
                {
                    DateTime fechaInicio = new DateTime(2000,1,1);
                    DateTime fechaFin = new DateTime(2025,1,1);

                    // valimaos y convertirmos fecha 
                    if (!string.IsNullOrWhiteSpace(fecha_inicio) && DateTime.TryParse(fecha_inicio, out DateTime parsedFechaInicio))
                    {
                        fechaInicio = parsedFechaInicio;
                    }

                    if (!string.IsNullOrWhiteSpace(fecha_fin) && DateTime.TryParse(fecha_fin, out DateTime parsedFechaFin))
                    {
                        fechaFin = parsedFechaFin;
                    }

                    var query = leonDb.consultarEventos(
                        lugar, // lugar 
                        turno, // turno
                        expositor, // expositor
                        Convert.ToInt32(empresa), //empresa
                        asociado, // asociaodo
                        ape_aso, // ape_asociado
                        fechaInicio, // fecha inicio
                        fechaFin, // fecha fin
                        Convert.ToInt32(estado) // estado
                        );

                    return query;

                }catch (Exception ex)
                {
                     return null;
                }
            }
        }

        [HttpPost]
        public ActionResult BuscarEventos(string lugar,string turno,string expositor,string empresa,
            string asociado, string ape_aso,string fecha_inicio,string fecha_fin, string estado)
        {
            var evento = new EventosViewModel();
            evento.Empresa = listarEmpresa();
            evento.Expositor = listarExpositor();
            evento.Asociado = listarAsociado();

            evento.Eventos = listarEventos(lugar,turno,expositor,empresa,asociado,ape_aso,fecha_inicio,fecha_fin,estado);



            if (evento.Asociado == null || !evento.Asociado.Any())
            {
                evento.ErrorAsociado = $"No se encontraron Expositor";
            }


            if (evento.Expositor == null || !evento.Expositor.Any())
            {
                evento.ErrorExpositor = $"No se encontraron Expositor";
            }

            if (evento.Empresa == null || !evento.Empresa.Any())
            {
                evento.ErrorEmpresa = $"No se encontraron Empresas";
            }

            if (evento.Eventos == null || !evento.Eventos.Any())
            {
                evento.ErrorMessage = $"No se encontraron eventos con los datos ingresados.";
            }

            return View("Index", evento);
        }

        

        public class EventosViewModel
        {
            public IEnumerable<EventosDc> Eventos { get; set; } 
            public string ErrorMessage { get; set; }
            public IEnumerable<ExpositorDC> Expositor { get; set;}
            public string ErrorExpositor { get; set; }

            public IEnumerable<EmpresasDC> Empresa { get; set; }
            public string ErrorEmpresa { get; set; }

            public IEnumerable<AsociadosDC> Asociado { get; set; }
            public string ErrorAsociado { get; set; }
        }
    }
}