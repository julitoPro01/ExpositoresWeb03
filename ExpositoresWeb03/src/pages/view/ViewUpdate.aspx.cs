using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpositoresWeb03.ServiceReferenceExpositor;

namespace ExpositoresWeb03.src.pages.view
{
    public partial class ViewUpdate : System.Web.UI.Page
    {

        string pageExpositorUrl = "~/src/pages/Expositor.aspx";

       public DateTime? fecha_registro { 
            get {
                return Session["fecha_registro"] is DateTime ? (DateTime?)Session["fecha_registro"] : null;
            }
            set { Session["fecha_registro"] = value; }
        }
       public byte[] img {
            get { return Session["img"] as byte[]; }
            set { Session["img"] = value; }   }

       public string usuario {
            get { return Session["usuario"] as string; }
            set { Session["usuario"]=value; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/src/pages/Inicio.aspx");

            if (!Page.IsPostBack)
            {
                if (Session["IdExpositor"] != null)
                {
                CargarDatos(Session["IdExpositor"].ToString());
                }
                else
                {
                    idLabelExpositor.Text += " !Seleccione un usuario para actualizar¡";
                   
                    IDcontainer_panel.Style.Add("display", "none");
                }
            }
            LabelOK.Text = "";

        }

        protected void CargarDatos(string id)
        {
            using(var expo = new ServicioExpositoresClient())
            {
                try
                {

                var result = expo.ConsultarExpositor(id);

                if (result != null)
                {
                idLabelExpositor.Text = result.Id_Expositor;
                InputPat.Text = result.Apellido_paterno;
                InputMat.Text = result.Apellido_materno;
                InputNom.Text = result.Nombre;
                InputTel.Text=result.Telefono;
                InputEma.Text = result.Email;
                InputDni.Text = result.Dni;
                InputDir.Text = result.Direccion;
                InputUbi.Text = result.Id_Ubigeo;
                
                textComentary.Text = result.Comentario;

                fecha_registro = result.Fec_Registro;
                img = result.Foto_Expositor;
                 usuario = result.Usu_Ult_Mod;

                if(result.estado_exp == 1)
                    RadioButtonList1.Items[0].Selected=true;   
                else
                 RadioButtonList1.Items[1].Selected =true;
                 
               
                     if(img != null && img.Length > 0)
                        {
                            string type = "image/jpeg";
                            string file = BitConverter.ToString(img.Take(4).ToArray()).Replace("-", "");

                            if (file.StartsWith("FFD8"))
                            {
                                type = "image/jpeg";
                            }
                            else if(file.StartsWith("89504E47"))
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
                {
                    throw new Exception("no se encontró ningún valor");
                }

                }catch(Exception ex)
                {
                    LabelError.Text = ex.Message;
                }
            }
        }

        protected void idBack_Click(object sender, EventArgs e)
        {
            Session["IdExpositor"]=null;
            Response.Redirect(pageExpositorUrl);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            
            using (var client = new ServicioExpositoresClient())
            {
                try
                {

                    
                     if (input_validar())
                       {

                           var result = client.ConsultarUbigeo(InputUbi.Text);

                           if (result != null)
                           {

                               var value = Input_Valores();

                                var ok =  client.ActualizarExpositor(value);
                                if (ok)
                                {

                                   LabelOK.Text = "Se actualizo correctamente "+value.Id_Expositor;
                                   string script = @"<script>openModal();</script>";
                                   ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModal", script, false);

                               }
                               else
                                {
                                   LabelOK.Text = "No se actualizo correctamente";

                                }

                           }
                           else
                           {
                               throw new Exception(Txtlabel("Ubigeo* :"));
                           }
                           // Response.Redirect(Session["PageExpositorUrl"].ToString());

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

        private ExpositorDC Input_Valores()
        {
            ExpositorDC expositorDC = new ExpositorDC
            {
                Id_Expositor = idLabelExpositor.Text,
                Apellido_paterno = InputPat.Text,
                Apellido_materno = InputMat.Text,
                Nombre = InputNom.Text,
                Telefono = InputTel.Text.Trim(),
                Email = InputEma.Text,
                Dni = InputDni.Text.Trim(),    
                Direccion = InputDir.Text,
                Id_Ubigeo = InputUbi.Text,
                Fec_Registro = fecha_registro,
                Fec_Ult_Mod = DateTime.Now,
                Usu_Ult_Mod = Session["user"].ToString(),
                Comentario = textComentary.Text,
               
            };

            if (RadioButtonList1.Items[0].Selected ==true )
            {
                expositorDC.estado_exp = 1;
            }else
                expositorDC.estado_exp = 0;

                expositorDC.Foto_Expositor = Session["img"] as byte[];
            

    
            return expositorDC;
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
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;
                return false;
            }
        }
        private String Txtlabel(string label)
        {
            return "Ingrese un valor valido en: " + label.Substring(0, label.Length - 3);

        }

        //CARGAR IMAGEN
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
