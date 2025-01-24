using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ExpositoresWeb03.ServiceReferenceUsuario;

namespace ExpositoresWeb03.src.pages
{
    public partial class Inicio : System.Web.UI.Page
    {
        //public string userAuth
        //{
        //    get { return Session["user"] as string; }
        //    set { Session["user"] = value; }    
           
        //} 

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["user"] == null)
            ModalPopupExtenderAuth.Show();
            
           
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            
            

            if (TextBoxNombre.Text.Trim() != "" || TextBoxPassword.Text.Trim() != "")
            {
              
               Boolean ok = consultarUser(TextBoxNombre.Text.Trim(), TextBoxPassword.Text.Trim());
                System.Threading.Thread.Sleep(3000);
               if(ok)
                {
                    ModalPopupExtenderAuth.Hide();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                    laberErrorUser.Text = "Usuario / contraseña no valido";

            }
            else
            {
                System.Threading.Thread.Sleep(3000);

                laberErrorUser.Text = "Usuario / contraseña no valido";


                ModalPopupExtenderAuth.Show();

            }
         
        }

        private Boolean consultarUser(string usuario, string contraseña)
        {
            try
            {
                using (var user = new UsuarioClient())
                {
                    var query = user.consultarUsuario(usuario, contraseña);
                    if (query != null)
                    {

                        Session["user"]= query.Login_Usuario.ToString();
                        LabelUsuario.Text = query.Login_Usuario.ToString();
                        return true;
                    }
                    else
                    {
                       
                        throw new Exception("Usuario / contraseña no valido");
                    }
                }

            }catch (Exception ex)
            {
                laberErrorUser.Text = ex.Message;
                return false;
            }
        }
    }
}