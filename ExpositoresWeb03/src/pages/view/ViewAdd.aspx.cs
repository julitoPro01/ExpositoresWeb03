using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ExpositoresWeb03.ServiceReferenceExpositor;

namespace ExpositoresWeb03.src.pages.Components
{
    public partial class ViewAdd : System.Web.UI.Page
    {
        string pageExpositorUrl = "~/src/pages/Expositor.aspx";
        public byte[] fileImg 
        {
            get { return Session["fileImg"] as byte[]; }
            set { Session["fileImg"]=value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!IsPostBack)
            {
                LabelError.Text = "";
               
            }

        }

        protected async void btn_save_Click(object sender, EventArgs e)
        {

           using( var client = new ServicioExpositoresClient())
            {
                try
                {
                    

                    if (input_validar())
                    {

                     var result = client.ConsultarUbigeo(InputUbi.Text);

                        if (result != null)
                        {

                            string script = @"<script>openModal();</script>";
                            var ok= client.InsertarExpositor(Input_Valores());
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
            using (var dbContext = new ServicioExpositoresClient())
            {
                var id = dbContext.ListarExpositor()
                    .OrderByDescending(e=>e.Id_Expositor)
                    .Select(e=>e.Id_Expositor).FirstOrDefault();

                if (string.IsNullOrEmpty(id))
                {
                    return "EXP001";
                }

                int sub = int.Parse(id.Substring(3));
                return "EXP"+(sub+1).ToString("D3");
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

            else if (!int.TryParse(InputTel.Text, out Num) || InputTel.Text.Length < 9)
                throw new Exception(Txtlabel(LabelTel.Text + InputTel.Text.Length.ToString()));

            else if (String.IsNullOrEmpty(InputEma.Text.Trim()) || !InputEma.Text.Contains("@"))
                throw new Exception(Txtlabel(LabelEma.Text));

            else if (!int.TryParse(InputDni.Text, out Num) || InputDni.Text.Length < 8)
                throw new Exception(Txtlabel(LabelDni.Text));

            else if (String.IsNullOrEmpty(InputDir.Text.Trim()))
                throw new Exception(Txtlabel("Dirección* :"));

            else if (!int.TryParse(InputUbi.Text, out Num) || InputUbi.Text.Length < 6)
                throw new Exception(Txtlabel("Ubigeo* :"));

            else
            {
                return true;
            }
            }catch (Exception ex)
            {
                LabelError.Text = ex.Message;
                return false;
            }
        }


        private ExpositorDC Input_Valores()
        {
            ExpositorDC expositorDC = new ExpositorDC
            {
                Id_Expositor = GenerarId(),
                Apellido_paterno = InputPat.Text,
                Apellido_materno = InputMat.Text,
                Nombre = InputNom.Text,
                Telefono = InputTel.Text,
                Email = InputEma.Text,
                Dni = InputDni.Text,
                Direccion = InputDir.Text,
                Id_Ubigeo = InputUbi.Text,
                Fec_Registro = DateTime.Now,
                Fec_Ult_Mod = DateTime.Now,
                Usu_Ult_Mod = Session["user"].ToString(),
                Comentario = textComentary.Text,
            };

           if( RadioButtonList1.Items[0].Selected == true)
            {
                expositorDC.estado_exp = 1;
            }
            else
            expositorDC.estado_exp=0;

            if (fileImg != null)
            expositorDC.Foto_Expositor = fileImg;
            else
                expositorDC.Foto_Expositor = null;

            return expositorDC;
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
            textComentary.Text = "";
        }

        //REDIRIGIRSE A INICIO
        protected void Button1_Click(object sender, EventArgs e)
        {
         
           // if(!String.IsNullOrEmpty(Session["PageExpositorUrl"].ToString()))
            Response.Redirect(pageExpositorUrl);

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