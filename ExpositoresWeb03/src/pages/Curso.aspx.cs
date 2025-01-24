using ExpositoresWeb03.ServiceReferenceCurso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpositoresWeb03.src.pages
{
    public partial class Curso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            smgOfDelete.Text = "";

            if (Page.IsPostBack == false)
            {
            Session["IdCurso"]=null;

                if (Session["user"] != null)
                CargarDatos("");
                else
                Response.Redirect("~/src/pages/Inicio.aspx");

            }
        }

        private void CargarDatos(string ape)
        {
            using (var cliente = new ServicioCursosClient())
            {
                try
                {

                    if (ape.Trim().Length == 0)
                    {

                        idCursoGrid.DataSource = cliente.ListarCursos();
                        count.Text = Convert.ToString(cliente.ListarCursos().Count());

                    }
                    else
                    {

                        idCursoGrid.DataSource = BuscarCurso(ape);

                    }
                    idCursoGrid.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }

        }

        public List<CursosDC> BuscarCurso(string desc)
        {
            using (var expositor = new ServicioCursosClient())
            {
                try
                {

                    return expositor.ListarCursos().Where(cur => cur.descripcion.Contains(desc)).ToList();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        protected void idCursoGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            idCursoGrid.PageIndex = e.NewPageIndex;
            CargarDatos("");



        }

        protected void search_TextChanged(object sender, EventArgs e)
        {

            CargarDatos(search.Text);

        }

        //SELECCIONAR FILA - GRIDVIEW
        protected void idCursoGrid_SelectedIndexChanged1(object sender, EventArgs e)
        {

            GridViewRow gridViewRow = idCursoGrid.SelectedRow;
            if (gridViewRow != null)
            {
                Session["IdCurso"] = gridViewRow.Cells[1].Text;
                gridViewRow.BackColor = System.Drawing.Color.DarkGray;

                foreach (GridViewRow row in idCursoGrid.Rows)
                {
                    if (row != gridViewRow)
                    {
                        row.BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
        }

        //ESTABLECIENTO EVENTO CLICK - CRIDVIEW
        protected void idCursoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(
                    idCursoGrid, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
                
            }
        }

        protected Boolean Eliminar_curso(string code)
        {
            using (var client = new ServicioCursosClient())
            {
                try
                {

                    client.EliminarCurso(code);
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

            if (Session["IdCurso"] == null)
            {
                labelConfirmar.Text = "Seleccione un elemento para eliminar";
            }
            else
            {

                var ok = Eliminar_curso(Session["IdCurso"].ToString());
                if (ok)
                    labelConfirmar.Text = "Eliminado: " + Session["IdCurso"];
                else
                    labelConfirmar.Text = "No sé pudo Eliminar";
            }
            Session["IdCurso"] = null;
        }

        // BOTON ABRIR MODAL
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["IdCurso"] != null)
            {

                labelConfirmar.Text = "Elemento seleccionado: " + Session["IdCurso"];
            }
            else
            {
                labelConfirmar.Text = "Seleccione un elemento para eliminar";
            }

        }

        //BOTON CERRAR MODAL
        protected void btnclosemodal_Click(object sender, EventArgs e)
        {

            if (Session["IdCurso"] == null)
            {
                count.Text = Convert.ToString(idCursoGrid.Rows.Count);
                CargarDatos("");
                UpdatePanel1.Update();
            }
        }
    }
}