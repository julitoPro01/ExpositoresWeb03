using ExpositoresWeb03.ServiceReferenceAsociado;
using ExpositoresWeb03.ServiceReferenceExpositor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages.view
{
    public partial class ViewUpdateAsociado : System.Web.UI.Page
    {
        string pageAsociadoUrl = "~/src/pages/Asociado.aspx";

        public DateTime? fecha_registro
        {
            get
            {
                return Session["fecha_registro"] is DateTime ? (DateTime?)Session["fecha_registro"] : null;
            }
            set { Session["fecha_registro"] = value; }
        }
        public byte[] img
        {
            get { return Session["img"] as byte[]; }
            set { Session["img"] = value; }
        }

        public string usuario
        {
            get { return Session["usuario"] as string; }
            set { Session["usuario"] = value; }
        }


        ServicioExpositoresClient ServicioExpositor = new ServicioExpositoresClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!IsPostBack)
            {
                LabelError.Text = "";
                if(Session["IdAsociado"] != null)
                {

                CargarEmpresa();
                ConsultarAsociado(Session["IdAsociado"].ToString());
                }
                else
                {
                    idLabelAsociado.Text += " !Seleccione un usuario para actualizar¡";

                    IDcontainer_panel.Style.Add("display", "none");
                }

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
                            var ok = client.ActualizarAsociados(Input_Valores());
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

        private void ConsultarAsociado(string codString)
        {
            try
            {
                using( var dbContext = new ServicioAsociadosClient())
                {
                    var query = dbContext.ConsultarAsociado(codString);
                    if (query != null)
                    {
                        idLabelAsociado.Text = query.cod_asociado;
                        InputPat.Text = query.ape_paterno;
                        InputMat.Text = query.ape_materno ;
                        InputNom.Text = query.nombres;
                        InputDir.Text = query.direccion;

                        Labelfechaingreso.InnerText = query.fecha_ingreso.ToString("d");
                        fechaIngreso.SelectedDate = query.fecha_ingreso;
                        InputDni.Text = query.dni;
                        InputTel.Text = query.tlf_domicilio;
                        InputCel.Text = query.tlf_celular;
                        InputEma.Text = query.correo;

                        LabelfechaUlCap.InnerText = query.fech_ult_capacitacion.ToString("d");
                        fechaUlCap.SelectedDate = query.fech_ult_capacitacion;
                        InputUbi.Text = query.Id_Ubigeo;

                        usuario = query.usuario_registro;
                        fecha_registro = query.fecha_registro;
                        img = query.foto;

                     var empresa = dbContext.ListarEmpresas().Where(em=>em.Id_Empresa == query.Id_Empresa).FirstOrDefault();
                        DropDownListEmp.Items.Insert(0, new ListItem(empresa.Razon_Social,empresa.Id_Empresa.ToString()));
    
                      if (query.estado_aso== 1)
                            RadioButtonList1.Items[0].Selected = true;
                        else
                            RadioButtonList1.Items[1].Selected = true;

                       
                        if (img != null && img.Length > 0)
                        {
                            string type = "image/jpeg";
                            string file = BitConverter.ToString(img.Take(4).ToArray()).Replace("-", "");

                            if (file.StartsWith("FFD8"))
                            {
                                type = "image/jpeg";
                            }
                            else if (file.StartsWith("89504E47"))
                            {
                                type = "image/png";
                            }

                            string base64String = Convert.ToBase64String(img);
                            ImageFoto.ImageUrl = $"data:{type};base64," + base64String;

                        }
                        else
                        {
                            ImageFoto.ImageUrl = "~/src/images/noimg.jpg";

                        }
                        
                    }
                    else
                        LabelError.Text = "No se encontró el Asociado con el id: "+codString;

                }

            }
            catch(Exception ex)
            {
                    LabelError.Text = ex.Message;
            }
        }


        private void CargarEmpresa()
        {
            try
            {
                using (var dbContext = new ServicioAsociadosClient())
                {
                    var query = dbContext.ListarEmpresas();
                    DropDownListEmp.DataSource = query;
                    DropDownListEmp.DataValueField = "Id_Empresa";
                    DropDownListEmp.DataTextField = "Razon_Social";
                    DropDownListEmp.DataBind();

                }

            }
            catch (Exception e)
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
                cod_asociado = Session["IdAsociado"].ToString(),
                ape_paterno = InputPat.Text,
                ape_materno = InputMat.Text,
                nombres = InputNom.Text,
                direccion = InputDir.Text,
                fecha_ingreso = Convert.ToDateTime(fechaIngreso.SelectedDate),
                dni = InputDni.Text,
                tlf_domicilio = InputTel.Text,
                tlf_celular = InputCel.Text,
                correo = InputEma.Text,
                fech_ult_capacitacion = Convert.ToDateTime(fechaUlCap.SelectedDate),
                Id_Empresa = Convert.ToInt32(DropDownListEmp.SelectedValue),
                Id_Ubigeo = InputUbi.Text,
                fecha_registro =Convert.ToDateTime( fecha_registro),
                usuario_ult_modificacion = Session["user"].ToString(),
                fecha_ult_modificacion = DateTime.Now,
                usuario_registro = usuario,

            };

            if (RadioButtonList1.Items[0].Selected == true)
            {
                asociadoDC.estado_aso = 1;
            }
            else
                asociadoDC.estado_aso = 0;

            if (img != null)
                asociadoDC.foto = img;
            else
                asociadoDC.foto = null;

            return asociadoDC;
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
                    img = imgByte;

                }

            }
        }
    }
}