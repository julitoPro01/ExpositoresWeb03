using ExpositoresWeb03.ServiceReferenceCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages.view
{
    public partial class ViewUpdateCurso : System.Web.UI.Page
    {
        string pageExpositorUrl = "~/src/pages/Curso.aspx";

        public DateTime? fecha_registro
        {
            get
            {
                return Session["fecha_registro"] is DateTime ? (DateTime?)Session["fecha_registro"] : null;
            }
            set { Session["fecha_registro"] = value; }
        }

        public string usuario
        {
            get { return Session["usuario"] as string; }
            set { Session["usuario"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!IsPostBack)
            {
                LabelError.Text = "";
                if(Session["IdCurso"] != null)
                {

                CargarEspecialidad();
                consultarCurso(Session["IdCurso"].ToString());
                }
                else
                {
                    PanelCurso.Style.Add("display", "none");
                    LabelIdCurso.Text = "!Seleccione un curos para actualizar¡";
                    LabelIdCurso.ForeColor=System.Drawing.Color.Red;
                }
            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            using (var client = new ServicioCursosClient())
            {
                try
                {

                    if (input_validar())
                    {


                        string script = @"<script>openModal();</script>";

                        var ok = client.ActualizarCursos(Input_Valores());
                        if (ok)
                        {
                          
                            IDmsgModal.Text = "Se actualizo correctamente";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "abrirModal", script, false);
                        }
                        else
                        {
                            LabelError.Text = "Error al actualizar, comuníquese con el administrador";
                        }
                        client.Close();
                    
                    }
                    

                }
                catch (Exception ex)
                {
                    client.Abort();
                    LabelError.Text = ex.Message;
                }

            }

        }
        private String Txtlabel(string label)
        {
            return "Ingrese un valor valido en: " + label.Substring(0, label.Length - 3);

        }
       

        // ----- CARGAMOS ESPECIALIDAD ----------
        private void CargarEspecialidad()
        {
            try
            {

                using (var dbContext = new ServicioCursosClient())
                {
                    List<EspecialidadDC> especialidadDCs = new List<EspecialidadDC>();

                    var query = dbContext.ListarEspecialidad();

                    DropDownListEsp.DataSource = query;
                    DropDownListEsp.DataValueField = "IdEspecialidad";
                    DropDownListEsp.DataTextField = "DescEspecialidad";
                    DropDownListEsp.DataBind();

                    }
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;

            }
        }


        private void consultarCurso(string id)
        {
            try
            {
                using(var dbContext = new ServicioCursosClient())
                {
                    var query = dbContext.ConsultarCurso(id);
                    if (query == null)
                    {
                        throw new Exception("No se encontró ningún curso con el id: "+id);
                    }
                    LabelIdCurso.Text = query.cod_curso;
                    InputDesc.Text = query.descripcion;
                    InputTeo.Text = query.horas_teoria.ToString();
                    InputPrac.Text = query.horas_practica.ToString();
                    InputCom.Text = query.comentarios.ToString();

                    DropDownListNivel.Items.Insert(0, new ListItem(query.nivel_dificultad,query.nivel_dificultad));
                    var espec = dbContext.ListarEspecialidad().Where(e => e.IdEspecialidad == query.IdEspecialidad).FirstOrDefault();
                    DropDownListEsp.Items.Insert(0, new ListItem(espec.DescEspecialidad,espec.IdEspecialidad.ToString()));
                    
                    if(query.estado_cur == 0)
                        RadioButtonList1.Items[1].Selected = true;
                    else
                        RadioButtonList1.Items[0].Selected = true;

                    fecha_registro = query.fecha_registro;
                    usuario = query.usuario_registro;

                }

            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;
            }
        }

        private Boolean input_validar()
        {
            try
            {

                int Num;



                if (String.IsNullOrEmpty(InputDesc.Text.Trim()))
                    throw new Exception(Txtlabel(LabelDesc.Text));

                else if (!int.TryParse(InputTeo.Text, out Num) || InputTeo.Text.Trim().Length > 2)
                    throw new Exception(Txtlabel(LabelTeo.Text));

                else if (!int.TryParse(InputPrac.Text, out Num) || InputPrac.Text.Trim().Length > 2)
                    throw new Exception(Txtlabel(LabelPrac.Text));

                else if (DropDownListNivel.SelectedValue.Trim() == "0")
                    throw new Exception(Txtlabel("Nivel de Dificultad* :"));

                else if (DropDownListEsp.SelectedValue.Trim() == "0")
                    throw new Exception(Txtlabel("Especialidad* :"));

                else if (String.IsNullOrEmpty(InputCom.Text.Trim()))
                    throw new Exception(Txtlabel("Comentario* :"));

                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;
                return false;
            }
        }


        private CursosDC Input_Valores()
        {
            CursosDC cursoDC = new CursosDC
            {
                cod_curso = Session["IdCurso"].ToString(),
                descripcion = InputDesc.Text,
                horas_teoria = Convert.ToInt32(InputTeo.Text),
                horas_practica = Convert.ToInt32(InputPrac.Text),
                nivel_dificultad = DropDownListNivel.SelectedValue,
                comentarios = InputCom.Text,
                IdEspecialidad = Convert.ToInt16(DropDownListEsp.SelectedValue),

                fecha_registro = Convert.ToDateTime(fecha_registro),

                usuario_registro = usuario,
                usuario_ult_modificacion = Session["user"].ToString(),

                fecha_ult_modificacion = DateTime.Now,

            };

            if (RadioButtonList1.Items[0].Selected == true)
            {
                cursoDC.estado_cur = 1;
            }
            else if (RadioButtonList1.Items[1].Selected == true)
                cursoDC.estado_cur = 0;

            return cursoDC;
        }


        //REDIRIGIRSE A INICIO
        protected void Button1_Click(object sender, EventArgs e)
        {

            // if(!String.IsNullOrEmpty(Session["PageExpositorUrl"].ToString()))
            Response.Redirect(pageExpositorUrl);

        }
    }
}