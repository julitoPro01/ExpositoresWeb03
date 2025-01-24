using ExpositoresWeb03.ServiceReferenceExpositor;
using ExpositoresWeb03.ServiceReferenceAsociado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages.view
{
    public partial class ViewAddAsociado : System.Web.UI.Page
    {
        string pageAsociadoUrl = "~/src/pages/Asociado.aspx";
        public byte[] fileImg
        {
            get { return Session["fileImg"] as byte[]; }
            set { Session["fileImg"] = value; }
        }

        ServicioExpositoresClient ServicioExpositor = new ServicioExpositoresClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!IsPostBack)
            {

                LabelError.Text = "";
                CargarEmpresa();
                fechaIngreso.SelectedDate = DateTime.Now;
                fechaUlCap.SelectedDate = DateTime.Now;
            }

        }

        protected async void btn_save_Click(object sender, EventArgs e)
        {

            using (var client = new ServicioAsociadosClient())
            {
                try
                {

                   if (input_validar())
                   {

                       var result = ServicioExpositor.ConsultarUbigeo(InputUbi.Text);

                      if (result != null)
                       {

                           string script = @"<script>openModal();</script>";
                           var ok = client.InsertarAsociados(Input_Valores());
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
                       }
                       else
                       {
                           throw new Exception(Txtlabel("Ubigeo* :"));
                       }
                       // Response.Redirect(Session["PageExpositorUrl"].ToString());
                   }
                    /*  
                    */


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
            using (var dbContext = new ServicioAsociadosClient())
            {
                var id = dbContext.ListarAsociados()
                    .OrderByDescending(e => e.cod_asociado)
                    .Select(e => e.cod_asociado).FirstOrDefault();

                if (string.IsNullOrEmpty(id))
                {
                    return "A001";
                }

                int sub = int.Parse(id.Substring(1));
                return "A" + (sub + 1).ToString("D3");
            }
        }

        private void CargarEmpresa()
        {
            try
            {
                using( var dbContext = new ServicioAsociadosClient())
                {
                    var query = dbContext.ListarEmpresas();
                    DropDownListEmp.DataSource = query;
                    DropDownListEmp.DataValueField = "Id_Empresa";
                    DropDownListEmp.DataTextField = "Razon_Social";
                    DropDownListEmp.DataBind();

                    DropDownListEmp.Items.Insert(0, new ListItem("-- Seleccione una empresa --", "0"));
                }

            }catch(Exception e)
            {
                    LabelError.Text = e.Message;
            }
        }

        private Boolean input_validar()
        {
            try
            {

                int Num;

                if (String.IsNullOrEmpty(InputPat.Text.Trim()))
                    throw new Exception(Txtlabel(LabelPat.Text));

                else if (String.IsNullOrEmpty(InputMat.Text.Trim()))
                    throw new Exception(Txtlabel(LabelMat.Text));

                else if (String.IsNullOrEmpty(InputNom.Text.Trim()))
                    throw new Exception(Txtlabel(LabelNom.Text));

                else if (!int.TryParse(InputTel.Text, out Num) || InputTel.Text.Length < 5)
                    throw new Exception(Txtlabel(LabelTelDom.Text + InputTel.Text.Length.ToString()));

                else if (!int.TryParse(InputCel.Text, out Num) || InputCel.Text.Length < 9)
                    throw new Exception(Txtlabel(LabelTelCel.Text + InputCel.Text.Length.ToString()));


                else if (String.IsNullOrEmpty(InputEma.Text.Trim()) || !InputEma.Text.Contains("@"))
                    throw new Exception(Txtlabel(LabelEma.Text));

                else if (!int.TryParse(InputDni.Text, out Num) || InputDni.Text.Length < 8)
                    throw new Exception(Txtlabel(LabelDni.Text));

                else if (DropDownListEmp.SelectedValue.Trim() == "0")
                    throw new Exception(Txtlabel("Empresa* :"));

                else if (String.IsNullOrEmpty(InputDir.Text.Trim()))
                    throw new Exception(Txtlabel("Dirección* :"));

                else if (!int.TryParse(InputUbi.Text, out Num) || InputUbi.Text.Length < 6)
                    throw new Exception(Txtlabel("Ubigeo* :"));

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


        private AsociadosDC Input_Valores()
        {
            AsociadosDC asociadoDC = new AsociadosDC
            {
                cod_asociado = GenerarId(),
                ape_paterno = InputPat.Text,
                ape_materno = InputMat.Text,
                nombres = InputNom.Text,
                direccion = InputDir.Text,
               fecha_ingreso = Convert.ToDateTime(Request.Form["fechaIngreso"]),
                dni = InputDni.Text,
                tlf_domicilio = InputTel.Text,
                tlf_celular = InputCel.Text,
                correo = InputEma.Text,
                fech_ult_capacitacion = Convert.ToDateTime( Request.Form["fechaUlCap"] ),
                Id_Empresa =Convert.ToInt32( DropDownListEmp.SelectedValue),
                Id_Ubigeo = InputUbi.Text,
                fecha_registro =DateTime.Now,
                usuario_ult_modificacion= Session["user"].ToString(),
                fecha_ult_modificacion=DateTime.Now,
                usuario_registro = Session["user"].ToString(),
                
            };

            if (RadioButtonList1.Items[0].Selected == true)
            {
                asociadoDC.estado_aso = 1;
            }
            else
                asociadoDC.estado_aso = 0;

            if (fileImg != null)
                asociadoDC.foto = fileImg;
            else
                asociadoDC.foto = null;

            return asociadoDC;
        }

        private void Input_limpiar()
        {
            InputPat.Text = "";
            InputMat.Text = "";
            InputNom.Text = "";
            InputTel.Text = "";
            InputEma.Text = "";
            InputDni.Text = "";
            InputDir.Text = "";
            InputUbi.Text = "";
            InputCel.Text = "";
            textComentary.Text = "";
            DropDownListEmp.Items.Clear();
        }

        //REDIRIGIRSE A INICIO
        protected void Button1_Click(object sender, EventArgs e)
        {

            // if(!String.IsNullOrEmpty(Session["PageExpositorUrl"].ToString()))
            Response.Redirect(pageAsociadoUrl);

        }

        protected void asyncFileUpload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (asyncFileUpload.HasFile)
            {

                string fileType = Path.GetExtension(asyncFileUpload.FileName).ToLower();
                if (fileType == ".jpg" || fileType == ".png")
                {
                    byte[] imgByte = asyncFileUpload.FileBytes;
                    fileImg = imgByte;

                }

            }
        }
    }
}