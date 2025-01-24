using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioExpositores" en el código y en el archivo de configuración a la vez.
    public class ServicioExpositores : IServicioExpositores
    {
        LeonComputingEntities9 leonComputingEntities = new LeonComputingEntities9();
        public List<ExpositorDC> ListarExpositor()
        {
            try
            {
                List<ExpositorDC> Expositor = new List<ExpositorDC>();

                var query = (from exp in leonComputingEntities.Tb_Expositor
                             select exp);

                //var query0 = leonComputingEntities.usp_ListarExpositores();

                foreach (var expositor in query)
                {

                    ExpositorDC objExpositor = new ExpositorDC
                    {
                        Id_Expositor = expositor.Id_Expositor,
                        Apellido_materno = expositor.Apellido_materno,
                        Apellido_paterno = expositor.Apellido_paterno,
                        Nombre = expositor.Nombre,
                        Direccion = expositor.Dirección,
                        Telefono = expositor.Telefono,
                        Email = expositor.E_mail,
                        Foto_Expositor = expositor.Foto_Expositor,
                        Comentario = expositor.Comentario,
                        Id_Ubigeo = expositor.Id_Ubigeo,
                        Departamento = expositor.Tb_Ubigeo.Departamento,
                        Provincia = expositor.Tb_Ubigeo.Provincia,
                        Distrito = expositor.Tb_Ubigeo.Distrito,
                        Dni = expositor.DNI,
                        Fec_Registro = Convert.ToDateTime(expositor.fecha_registro),
                        Usu_Ult_Mod = expositor.usuario_ult_modificacion,
                        Fec_Ult_Mod = Convert.ToDateTime(expositor.fecha_ult_modificacion),
                        estado_exp = Convert.ToInt32(expositor.estado_exp)

                    };

                    if (expositor.estado_exp == 0)
                        objExpositor.tipo_estado = "Inactivo";
                    else
                        objExpositor.tipo_estado = "Activo";

                    Expositor.Add(objExpositor);
                }
                return Expositor;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarExpositor(ExpositorDC Exp)
        {
            try
            {

                leonComputingEntities.usp_ActualizarExpositor(
                Exp.Id_Expositor,
                Exp.Apellido_materno,
                Exp.Apellido_paterno,
                Exp.Nombre,
                Exp.Direccion,
                Exp.Telefono,
                Exp.Email,
                Convert.ToString(Exp.Dni),
                Exp.Foto_Expositor,
                Exp.Comentario,
                Exp.Id_Ubigeo,
                Exp.Fec_Registro,
                Exp.Usu_Ult_Mod,
                Exp.Fec_Ult_Mod,
                Exp.estado_exp
                    );

                leonComputingEntities.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarExpositor(String strCodigo)
        {
            try
            {


                leonComputingEntities.usp_EliminarExpositor(strCodigo);


                leonComputingEntities.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }

        }

      

        public Boolean InsertarExpositor(ExpositorDC Exp)
        {
            try
            {

                leonComputingEntities.usp_InsertarExpositor(
                Exp.Id_Expositor,
                Exp.Apellido_materno,
                Exp.Apellido_paterno,
                Exp.Nombre,
                Exp.Direccion,
                Exp.Telefono,
                Exp.Email,
                Exp.Dni,
                Exp.Foto_Expositor,
                Exp.Comentario,
                Exp.Id_Ubigeo,
                Exp.Fec_Registro,
                Exp.Usu_Ult_Mod,
                Exp.Fec_Ult_Mod,
                Exp.estado_exp
                );

                leonComputingEntities.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    public ExpositorDC ConsultarExpositor(string id)
        {
            try
            {

             var expo =  leonComputingEntities.usp_ConsultarExpositor(id).Select(e =>
            {
                return new ExpositorDC
                {
                    Id_Expositor =e.Id_Expositor,
                    Apellido_materno = e.Apellido_materno,
                    Apellido_paterno =e.Apellido_paterno,
                    Nombre = e.Nombre,
                    Direccion = e.Dirección,
                    Telefono = e.Telefono,
                    Email = e.E_mail,
                    Foto_Expositor = e.Foto_Expositor,
                    Comentario = e.Comentario,
                    Id_Ubigeo = e.Id_Ubigeo,
                    Dni = e.DNI,
                    Fec_Registro = Convert.ToDateTime(e.fecha_registro),
                    Usu_Ult_Mod = e.usuario_ult_modificacion,
                    Fec_Ult_Mod = Convert.ToDateTime(e.fecha_ult_modificacion),
                    estado_exp = Convert.ToInt32(e.estado_exp)
                };
            }).FirstOrDefault();

                if(expo != null)
                    return expo;
                

                return null;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

     public UbigeoDc ConsultarUbigeo(string id)
        {

            try
            {
           var contex = leonComputingEntities.Tb_Ubigeo.Find(id);

                if (contex != null)
                {

            return new UbigeoDc
            {
                Id_Ubigeo = id,
                IdDepa  = contex.IdDepa,
                IdProv = contex.IdProv,
                IdDist = contex.IdDist,
                Departamento = contex.Departamento, 
                Provincia = contex.Provincia,
                Distrito = contex.Distrito,
            };
                }

            return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

    }

}
