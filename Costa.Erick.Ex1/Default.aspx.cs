using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Costa.Erick.Ex1.LogicaNegocio;

namespace Costa.Erick.Ex1
{
    public partial class _Default : Page
    {
        private RecetaBL bl = new RecetaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ok"] != null) lblMensaje.Text = "Receta guardada correctamente.";
                Cargar();
            }
        }

        // READ
        private void Cargar()
        {
            gvRecetas.DataSource = bl.Listar();
            gvRecetas.DataBind();
        }

        // DELETE
        protected void gvRecetas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvRecetas.DataKeys[e.RowIndex].Value;
            bl.Eliminar(id);
            lblMensaje.Text = "Receta eliminada correctamente.";
            Cargar();
        }
    }
}
