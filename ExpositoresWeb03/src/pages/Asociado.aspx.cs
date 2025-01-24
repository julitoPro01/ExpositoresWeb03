using ExpositoresWeb03.ServiceReferenceAsociado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages
{
    public partial class Asociado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            smgOfDelete.Text = "";

            if (Page.IsPostBack == false)
            {
            Session["IdAsociado"]=null;
                if (Session["user"] !=null)
                CargarDatos("");
                else
                    Response.Redirect("~/src/pages/Inicio.aspx");

            }
        }

        private void CargarDatos(string ape)
        {
            using (var cliente = new ServicioAsociadosClient())
            {
                try
                {

                    if (ape.Trim().Length == 0)
                    {

                        idAsociadoGrid.DataSource = cliente.ListarAsociados();
                        count.Text = Convert.ToString(cliente.ListarAsociados().Count());

                    }
                    else
                    {

                        idAsociadoGrid.DataSource = BuscarAsociado(ape);

                    }
                    idAsociadoGrid.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }

        }

        public List<AsociadosDC> BuscarAsociado(string ape)
        {
            using (var asociado = new ServicioAsociadosClient())
            {
                try
                {

                    return asociado.ListarAsociados().Where(aso => aso.ape_paterno.Contains(ape)).ToList();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        protected void idAsociadoGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            idAsociadoGrid.PageIndex = e.NewPageIndex;
            CargarDatos("");



        }

        protected void search_TextChanged(object sender, EventArgs e)
        {

            CargarDatos(search.Text);

        }

        //SELECCIONAR FILA - GRIDVIEW
        protected void idAsociadoGrid_SelectedIndexChanged1(object sender, EventArgs e)
        {

            GridViewRow gridViewRow = idAsociadoGrid.SelectedRow;
            if (gridViewRow != null)
            {
                Session["IdAsociado"] = gridViewRow.Cells[1].Text;
                gridViewRow.BackColor = System.Drawing.Color.DarkGray;

                foreach (GridViewRow row in idAsociadoGrid.Rows)
                {
                    if (row != gridViewRow)
                    {
                        row.BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
        }

        //ESTABLECIENTO EVENTO CLICK - CRIDVIEW
        protected void idAsociadoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(
                    idAsociadoGrid, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
                Image imgFoto = (Image)e.Row.FindControl("imgFoto");
                byte[] fotoBytes = DataBinder.Eval(e.Row.DataItem, "foto") as byte[];

                if (fotoBytes != null)
                {

                    string base64String = Convert.ToBase64String(fotoBytes);
                    imgFoto.ImageUrl = "data:image/jpeg;base64," + base64String; 
                }
                else
                {
                    imgFoto.ImageUrl = "~/src/images/noimg.jpg"; // Imagen por defecto
                }
            }
        }

        protected Boolean Eliminar_asociado(string code)
        {
            using (var client = new ServicioAsociadosClient())
            {
                try
                {

                    client.EliminarAsociados(code);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //BOTON - CONFIRMAR ELIMINAR
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Session["IdAsociado"] == null)
            {
                labelConfirmar.Text = "Seleccione un elemento para eliminar "+ Session["IdAsociado"];
            }
            else
            {

                var ok = Eliminar_asociado(Session["IdAsociado"].ToString());
                if (ok)
                    labelConfirmar.Text = "Eliminado: " + Session["IdAsociado"];
                else
                    labelConfirmar.Text = "No sé pudo Eliminar";
            }
            Session["IdAsociado"] = null;
        }

        // BOTON ABRIR MODAL
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["IdAsociado"] != null)
            {

                labelConfirmar.Text = "Elemento seleccionado: " + Session["IdAsociado"];
            }
            else
            {
                labelConfirmar.Text = "Seleccione un elemento para eliminar";
            }

        }

        //BOTON CERRAR MODAL
        protected void btnclosemodal_Click(object sender, EventArgs e)
        {

            if (Session["IdAsociado"] == null)
            {
                count.Text = Convert.ToString(idAsociadoGrid.Rows.Count);
                CargarDatos("");
                UpdatePanel1.Update();
            }
        }
    }
}