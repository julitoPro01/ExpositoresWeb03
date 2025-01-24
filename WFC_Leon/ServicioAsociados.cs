using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioAsociados" en el código y en el archivo de configuración a la vez.
    public class ServicioAsociados : IServicioAsociados
    {
        public bool ActualizarAsociados(AsociadosDC asociado)
        {
            try
            {
                using( LeonComputingEntities9 LeonDb = new LeonComputingEntities9())
                {
                    var query = (from Asociado in LeonDb.Tb_Asociado 
                                 where Asociado.cod_asociado == asociado.cod_asociado
                                 select Asociado ).FirstOrDefault();
                    if( query == null ) {
                        throw new Exception("El registro con el código especificado no fue encontrado.");
                    }

                    query.cod_asociado = asociado.cod_asociado;
                    query.ape_paterno = asociado.ape_paterno;
                    query.ape_materno = asociado.ape_materno;
                    query.nombres = asociado.nombres;
                    query.direccion = asociado.direccion;
                    query.fecha_ingreso = asociado.fecha_ingreso;
                    query.dni = asociado.dni;
                    query.tlf_domicilio = asociado.tlf_domicilio;
                    query.tlf_celular = asociado.tlf_celular;
                    query.correo = asociado.correo;
                    query.fech_ult_capacitacion = asociado.fech_ult_capacitacion;
                    query.foto = asociado.foto; 
                    query.Id_Empresa = asociado.Id_Empresa;
                    query.Id_Ubigeo = asociado.Id_Ubigeo;
                    query.fecha_registro = asociado.fecha_registro;
                    query.usuario_ult_modificacion = asociado.usuario_ult_modificacion;
                    query.fecha_ult_modificacion = asociado.fecha_ult_modificacion;
                    query.usuario_registro = asociado.usuario_registro;
                    query.estado_aso = asociado.estado_aso;

                  LeonDb.SaveChanges();
                }

                return true;
            }catch (EntityException ex)
            {
                throw new Exception(ex.Message,ex);
            }
            
        }

        public AsociadosDC ConsultarAsociado(string id)
        {
            try
            {

                using( LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {
                    var query = leonDb.Tb_Asociado.Find(id);
                    return new AsociadosDC {
                    cod_asociado= query.cod_asociado,
                    ape_paterno = query.ape_paterno,
                    ape_materno = query.ape_materno,
                    nombres = query.nombres,
                    direccion = query.direccion,
                    fecha_ingreso = Convert.ToDateTime( query.fecha_ingreso),
                    dni = query.dni,
                    tlf_domicilio = query.tlf_domicilio,
                    tlf_celular = query.tlf_celular,
                    correo = query.correo,
                    fech_ult_capacitacion =Convert.ToDateTime( query.fech_ult_capacitacion),
                    foto = query.foto,
                    Id_Empresa = query.Id_Empresa ,
                    Id_Ubigeo= query.Id_Ubigeo,
                    fecha_registro =Convert.ToDateTime( query.fecha_registro),
                        usuario_ult_modificacion = query.usuario_ult_modificacion,
                    fecha_ult_modificacion=Convert.ToDateTime( query.fecha_ult_modificacion),
                    usuario_registro =  query.usuario_registro,
                    estado_aso =Convert.ToInt16( query.estado_aso)
                };

                }
                

            }catch (EntityException ex)
            {
                throw new Exception (ex.Message,ex);
            }
        }

        public bool EliminarAsociados(string strCodigo)
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {
                    var query = leonDb.usp_EliminarAsociado(strCodigo);
                    leonDb.SaveChanges();
                    
                    return true;
                }


            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public bool InsertarAsociados(AsociadosDC asociado)
        {
            try
            {
                using (LeonComputingEntities9 LeonDb = new LeonComputingEntities9())
                {
                    var query = new Tb_Asociado();

                    query.cod_asociado = asociado.cod_asociado;
                    query.ape_paterno = asociado.ape_paterno;
                    query.ape_materno = asociado.ape_materno;
                    query.nombres = asociado.nombres;
                    query.direccion = asociado.direccion;
                    query.fecha_ingreso = asociado.fecha_ingreso;
                    query.dni = asociado.dni;
                    query.tlf_domicilio = asociado.tlf_domicilio;
                    query.tlf_celular = asociado.tlf_celular;
                    query.correo = asociado.correo;
                    query.fech_ult_capacitacion = asociado.fech_ult_capacitacion;
                    query.foto = asociado.foto;
                    query.Id_Empresa = asociado.Id_Empresa;
                    query.Id_Ubigeo = asociado.Id_Ubigeo;
                    query.fecha_registro = asociado.fecha_registro;
                    query.usuario_ult_modificacion = asociado.usuario_ult_modificacion;
                    query.fecha_ult_modificacion = asociado.fecha_ult_modificacion;
                    query.usuario_registro = asociado.usuario_registro;
                    query.estado_aso = asociado.estado_aso;

                    LeonDb.Tb_Asociado.Add(query);
                    LeonDb.SaveChanges();
                }

                return true;


            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<AsociadosDC> ListarAsociados()
        {
            try
            {
                using( LeonComputingEntities9 leonDb = new LeonComputingEntities9() )
                {
                    var query = leonDb.Tb_Asociado.ToList();


                        List<AsociadosDC> asociadosDCs = new List<AsociadosDC>();
                    foreach(var asociado in query)
                    {
                        AsociadosDC asoc = new AsociadosDC
                        {
                            cod_asociado = asociado.cod_asociado,
                            ape_paterno = asociado.ape_paterno,
                            ape_materno = asociado.ape_materno,
                            nombres = asociado.nombres,
                            direccion = asociado.direccion,
                            fecha_ingreso = Convert.ToDateTime(asociado.fecha_ingreso),
                            dni = asociado.dni,
                            tlf_domicilio = asociado.tlf_domicilio,
                            tlf_celular = asociado.tlf_celular,
                            correo = asociado.correo,
                            fech_ult_capacitacion = Convert.ToDateTime(asociado.fech_ult_capacitacion),
                            foto = asociado.foto,
                            Id_Empresa = asociado.Id_Empresa,
                            Id_Ubigeo = asociado.Id_Ubigeo,
                            fecha_registro = Convert.ToDateTime(asociado.fecha_registro),
                            usuario_ult_modificacion = asociado.usuario_ult_modificacion,
                            fecha_ult_modificacion = Convert.ToDateTime(asociado.fecha_ult_modificacion),
                            usuario_registro = asociado.usuario_registro,
                            estado_aso = Convert.ToInt16(asociado.estado_aso)
                        };

                        if (asoc.estado_aso == 0)
                            asoc.estado = "Inactivo";
                        else asoc.estado = "Activo";

                        asociadosDCs.Add(asoc);
                        
                    }

                    return asociadosDCs;
                }
            }
            catch(EntityException e) {
                throw new Exception(e.Message, e);
            }
        }

        public List<EmpresasDC> ListarEmpresas()
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9() )
                {
                    List<EmpresasDC> empresasDCs = new List<EmpresasDC>();

                    var query = leonDb.Tb_Empresa.ToList();

                    foreach (var empresasDC in query)
                    {
                        empresasDCs.Add(new EmpresasDC{
                        Id_Empresa = empresasDC.Id_Empresa,
                        Razon_Social = empresasDC.Razon_Social,
                        Direccion = empresasDC.Direccion,
                        Telefono1 = empresasDC.Telefono1,
                        Telefono2 = empresasDC.Telefono2,
                        UrlPagWeb = empresasDC.UrlPagWeb,
                        Id_Ubigeo = empresasDC.Id_Ubigeo,
                        fecha_registro = Convert.ToDateTime( empresasDC.fecha_registro),
                        usuario_ult_modificacion = empresasDC.usuario_ult_modificacion,
                        fecha_ult_modificacion= Convert.ToDateTime(empresasDC.fecha_ult_modificacion),
                        estado_emp = Convert.ToInt32(empresasDC.estado_emp),

                        });
                    }

                    return empresasDCs;
                }

            }catch(Exception e) {
                throw new Exception(e.Message, e);
             }
        }
    }
}
