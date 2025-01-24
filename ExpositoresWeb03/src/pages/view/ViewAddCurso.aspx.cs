using AjaxControlToolkit;
using ExpositoresWeb03.ServiceReferenceCurso;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages.view
{
    public partial class ViewAddCurso : System.Web.UI.Page
    {
        string pageExpositorUrl = "~/src/pages/Curso.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!IsPostBack)
            {
                LabelError.Text = "";
               CargarEspecialidad();
            }

        }

        protected async void btn_save_Click(object sender, EventArgs e)
        {

            using (var client = new ServicioCursosClient())
            {
                try
                {
                    
                if (input_validar())
                {


                     string script = @"<script>openModal();</script>";

                     var ok = client.InsertarCurso(Input_Valores());
                     if (ok)
                     {
                         Input_limpiar();
                         IDmsgModal.Text = "Se correctamente";
                         ScriptManager.RegisterStartupScript(this, this.GetType(), "abrirModal", script, false);
                     }
                     else
                     {
                         LabelError.Text = "Error al añadir, comuníquese con el administrador";
                     }
                     client.Close();
                    /*
                    */
                }
                        // Response.Redirect(Session["PageExpositorUrl"].ToString());


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
        private string GenerarId()
        {
            using (var dbContext = new ServicioCursosClient())
            {
                var id = dbContext.ListarCursos()
                    .OrderByDescending(e => e.cod_curso)
                    .Select(e => e.cod_curso).FirstOrDefault();

                if (string.IsNullOrEmpty(id))
                {
                    return "C01";
                }

                int sub = int.Parse(id.Substring(1));
                return "C" + (sub + 1).ToString("D2");
            }
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

                DropDownListEsp.Items.Insert(0, new ListItem("-- Seleccione una especialidad --","0"));
            }
            }catch (Exception ex)
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

                else if (!int.TryParse(InputTeo.Text, out Num) || InputTeo.Text.Trim().Length > 2 )
                    throw new Exception(Txtlabel(LabelTeo.Text));

                else if (!int.TryParse(InputPrac.Text, out Num) || InputPrac.Text.Trim().Length > 2)
                    throw new Exception(Txtlabel(LabelPrac.Text));

                else if (DropDownListNivel.SelectedValue.Trim() == "0")
                    throw new Exception(Txtlabel("Nivel de Dificultad* :"));

                else if(DropDownListEsp.SelectedValue.Trim() == "0")
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
                cod_curso = GenerarId(),
                descripcion = InputDesc.Text,
                horas_teoria = Convert.ToInt32 (InputTeo.Text),
                horas_practica = Convert.ToInt32(InputPrac.Text),
                nivel_dificultad = DropDownListNivel.SelectedValue,
                comentarios = InputCom.Text,
                IdEspecialidad = Convert.ToInt16( DropDownListEsp.SelectedValue),
              fecha_registro = DateTime.Now,
              usuario_registro = "Ploper",
              usuario_ult_modificacion = Session["user"].ToString(),
              fecha_ult_modificacion = DateTime.Now,
             
            };

            if (RadioButtonList1.Items[0].Selected == true)
            {
                cursoDC.estado_cur = 1;
            }
            else if(RadioButtonList1.Items[1].Selected == true)
                cursoDC.estado_cur = 0;
            
            return cursoDC;
        }

        private void Input_limpiar()
        {
            InputDesc.Text = "";
            InputTeo.Text = "";
            InputPrac.Text = "";
            DropDownListNivel.ClearSelection();
            DropDownListEsp.ClearSelection();
            InputCom.Text = "";
        }

        //REDIRIGIRSE A INICIO
        protected void Button1_Click(object sender, EventArgs e)
        {

            // if(!String.IsNullOrEmpty(Session["PageExpositorUrl"].ToString()))
            Response.Redirect(pageExpositorUrl);

        }

    }
}