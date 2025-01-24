using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WFC_Leon
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCursos" en el código y en el archivo de configuración a la vez.
    public class ServicioCursos : IServicioCursos
    {
        public bool ActualizarCursos(CursosDC curso)
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {

                    var query = leonDb.Tb_Curso.Find(curso.cod_curso);
                    if (query == null)
                    {
                        return false;
                    }
                    query.descripcion = curso.descripcion;
                    query.horas_teoria = curso.horas_teoria;
                    query.horas_practica = curso.horas_practica;
                    query.nivel_dificultad = curso.nivel_dificultad;
                    query.comentarios = curso.comentarios;
                    query.IdEspecialidad = curso.IdEspecialidad;
                    query.fecha_registro = curso.fecha_registro;
                    query.usuario_registro = curso.usuario_registro;
                    query.usuario_ult_modificacion = curso.usuario_ult_modificacion;
                    query.fecha_ult_modificacion = curso.fecha_ult_modificacion;
                    query.estado_cur = curso.estado_cur;

                    leonDb.SaveChanges();
                    return true;
                }

            }
            catch (EntityException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public CursosDC ConsultarCurso(string id)
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {

                    var query = leonDb.Tb_Curso.Find(id);
                    if (query == null)
                    {
                        return null;
                    }

                    return new CursosDC
                    {
                        cod_curso = query.cod_curso,
                        descripcion = query.descripcion,
                        horas_teoria = Convert.ToInt16(query.horas_teoria),
                        horas_practica = Convert.ToInt16(query.horas_practica),
                        nivel_dificultad = query.nivel_dificultad,
                        comentarios = query.comentarios,
                        IdEspecialidad = Convert.ToInt16(query.IdEspecialidad),
                        fecha_registro = Convert.ToDateTime(query.fecha_registro),
                        usuario_registro = query.usuario_registro,
                        usuario_ult_modificacion = query.usuario_ult_modificacion,
                        fecha_ult_modificacion = Convert.ToDateTime(query.fecha_ult_modificacion),
                        estado_cur = Convert.ToInt16(query.estado_cur)
                    };
                    

                }

            }
            catch (EntityException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public bool EliminarCurso(string strCodigo)
        {
            try
            {

                using( LeonComputingEntities9 leonDb = new LeonComputingEntities9()) { 
                    leonDb.usp_EliminarCurso(strCodigo);
                    leonDb.SaveChanges();
                    return true;
                }

            }catch(EntityException e)
            {
                throw new Exception(e.Message,e);
            }
        }

        public bool InsertarCurso(CursosDC curso)
        {
            try
            {

                using(LeonComputingEntities9 leonDb =new LeonComputingEntities9()) {

                          var query = new Tb_Curso();
                            query.cod_curso = curso.cod_curso;
                            query.descripcion = curso.descripcion;
                            query.horas_teoria = curso.horas_teoria;
                            query.horas_practica = curso.horas_practica;
                            query.nivel_dificultad = curso.nivel_dificultad;
                            query.comentarios = curso.comentarios;
                            query.IdEspecialidad = curso.IdEspecialidad;
                            query.fecha_registro = curso.fecha_registro;
                            query.usuario_registro = curso.usuario_registro;
                            query.usuario_ult_modificacion = curso.usuario_ult_modificacion;
                            query.fecha_ult_modificacion = curso.fecha_ult_modificacion;
                            query.estado_cur = curso.estado_cur;

                    leonDb.Tb_Curso.Add(query);
                    leonDb.SaveChanges();

                    return true;
                }

            }catch(EntityException e)
            {
                throw new Exception(e.Message,e);
            }
        }

        public List<CursosDC> ListarCursos()
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {
                    List<CursosDC> cursosDCs = new List<CursosDC>();
                    var query = leonDb.Tb_Curso.ToList();
                    foreach (var curso in query)
                    {
                        CursosDC cursoObj = new CursosDC
                        {
                            cod_curso = curso.cod_curso,
                            descripcion = curso.descripcion,
                            horas_teoria = Convert.ToInt16( curso.horas_teoria),
                            horas_practica = Convert.ToInt16( curso.horas_practica),
                            nivel_dificultad = curso.nivel_dificultad,
                            comentarios = curso.comentarios,
                            IdEspecialidad =Convert.ToInt16( curso.IdEspecialidad),
                            fecha_registro = Convert.ToDateTime( curso.fecha_registro ),
                            usuario_registro = curso.usuario_registro,
                            usuario_ult_modificacion = curso.usuario_ult_modificacion,
                            fecha_ult_modificacion = Convert.ToDateTime(curso.fecha_ult_modificacion),
                            estado_cur = Convert.ToInt16(curso.estado_cur),

                        };

                        if (cursoObj.estado_cur == 0)
                        {
                            cursoObj.estado = "Inactivo";
                        }
                        else if (cursoObj.estado_cur == 1)
                            cursoObj.estado = "Activo";
                        else
                        {
                            cursoObj.estado = "Suspendido";
                        }

                        cursosDCs.Add(cursoObj);
                    }

                    return cursosDCs;
                }

            }
            catch (EntityException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<EspecialidadDC> ListarEspecialidad()
        {
            try
            {

                using (LeonComputingEntities9 leonDb = new LeonComputingEntities9())
                {
                    List<EspecialidadDC> especialidadDCs = new List<EspecialidadDC>();
                    var query = leonDb.Tb_Especialidad.ToList();

                    foreach (var especialidadDC in query)
                    {
                        especialidadDCs.Add(new EspecialidadDC
                        {
                            IdEspecialidad = especialidadDC.IdEspecialidad,
                            DescEspecialidad = especialidadDC.DescEspecialidad
                        });

                    }

                    return especialidadDCs;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        }

}
