using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.Components
{
    public partial class NavBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

            LabelUser.Text = Session["user"].ToString();
            }
        }

        protected void CerrarEventoLeon_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
             Response.Redirect("~/src/pages/Inicio.aspx");

        }
    }
}