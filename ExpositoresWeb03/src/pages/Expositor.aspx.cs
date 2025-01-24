using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExpositoresWeb03.ServiceReferenceExpositor;

namespace ExpositoresWeb03.src.pages
{
    public partial class Expositor : System.Web.UI.Page
    {

             
        protected void Page_Load(object sender, EventArgs e)
        {
            smgOfDelete.Text = "";
            if (Page.IsPostBack == false)
            {
            Session["IdExpositor"]=null;

                if (Session["user"] != null)
                CargarDatos("");
                else
                    Response.Redirect("~/src/pages/Inicio.aspx");

            }
        }

        private void CargarDatos( string ape)
        {
           using(var cliente = new ServicioExpositoresClient())
            {
                try
                {

                    if(ape.Trim().Length == 0)
                    {

                    idExpositorGrid.DataSource = cliente.ListarExpositor();
                        count.Text =Convert.ToString( cliente.ListarExpositor().Count());
                      
                    }
                    else
                    {

                        idExpositorGrid.DataSource=BuscarExpositor(ape);
                     
                    }
                    idExpositorGrid.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
               
            }
           
        }

        public  List<ExpositorDC> BuscarExpositor(string ape)
        {
            using(var expositor = new ServicioExpositoresClient())
            {
                try
                {
                   
                 return expositor.ListarExpositor().Where(exp => exp.Apellido_paterno.Contains(ape)).ToList();
                       
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        protected void idExpositorGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            idExpositorGrid.PageIndex = e.NewPageIndex;
           CargarDatos("");
                   


        }

        protected void search_TextChanged(object sender, EventArgs e)
        {
          
            CargarDatos(search.Text);
          
        }

        //SELECCIONAR FILA - GRIDVIEW
        protected void idExpositorGrid_SelectedIndexChanged1(object sender, EventArgs e)
        {

            GridViewRow gridViewRow = idExpositorGrid.SelectedRow;
            if (gridViewRow != null)
            {
                Session["IdExpositor"] = gridViewRow.Cells[1].Text;
                gridViewRow.BackColor = System.Drawing.Color.DarkGray;
               
                foreach (GridViewRow row in idExpositorGrid.Rows)
                {
                    if(row != gridViewRow)
                    {
                        row.BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }    
        }

        //ESTABLECIENTO EVENTO CLICK - CRIDVIEW
        protected void idExpositorGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(
                    idExpositorGrid, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
                Image imgFoto = (Image)e.Row.FindControl("imgFoto");
                byte[] fotoBytes = DataBinder.Eval(e.Row.DataItem, "Foto_Expositor") as byte[];

                if (fotoBytes != null)
                {

                    string base64String = Convert.ToBase64String(fotoBytes);
                    imgFoto.ImageUrl = "data:image/jpeg;base64," + base64String; // solo formato jpg
                }
                else
                {
                    imgFoto.ImageUrl = "~/src/images/noimg.jpg"; // Imagen por defecto
                }
            }
        }

        protected Boolean Eliminar_expositor(string code)
        {
            using(var client =new ServicioExpositoresClient())
            {
                try
                {

                client.EliminarExpositor(code);
                    return true;
                }
                 catch(Exception ex)
                {
                    return false;
                } 
            }
        }

        //BOTON - CONFIRMAR ELIMINAR
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Session["IdExpositor"] == null)
            {
            labelConfirmar.Text = "Seleccione un elemento para eliminar";
            }
            else
            {

               var ok = Eliminar_expositor(Session["IdExpositor"].ToString());
                if (ok)
                    labelConfirmar.Text = "Eliminado: " + Session["IdExpositor"];
                else
                    labelConfirmar.Text = "No sé pudo Eliminar";
            }
            Session["IdExpositor"] = null;
        }

        // BOTON ABRIR MODAL
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["IdExpositor"] !=null)
            {

            labelConfirmar.Text = "Elemento seleccionado: "+ Session["IdExpositor"];
            }
            else
            {
                labelConfirmar.Text = "Seleccione un elemento para eliminar";
            }

        }

        //BOTON CERRAR MODAL
        protected void btnclosemodal_Click(object sender, EventArgs e)
        {
                
                if(Session["IdExpositor"] == null)
            {
                count.Text =Convert.ToString(idExpositorGrid.Rows.Count);
                CargarDatos("");
                UpdatePanel1.Update();
            }
        }
    }
}
