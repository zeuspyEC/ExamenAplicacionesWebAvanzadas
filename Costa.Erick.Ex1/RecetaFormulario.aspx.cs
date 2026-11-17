using System;
using System.Web.UI;
using Costa.Erick.Ex1.Entidades;
using Costa.Erick.Ex1.LogicaNegocio;

namespace Costa.Erick.Ex1
{
    public partial class RecetaFormulario : Page
    {
        private RecetaBL bl = new RecetaBL();

        // Id de la receta en edición (0 = nueva)
        private int Id
        {
            get { return Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Id > 0)
            {
                // UPDATE: se cargan los datos actuales
                Receta r = bl.Obtener(Id);
                if (r == null) Response.Redirect("Default.aspx");
                lblTitulo.Text = "Editar receta #" + r.RecetaId;
                txtNombre.Text = r.Nombre;
                txtPais.Text = r.PaisOrigen;
                txtIngredientes.Text = r.Ingredientes;
                txtTiempo.Text = r.TiempoPreparacion.ToString();
                rblVegetariana.SelectedValue = r.Vegetariana ? "1" : "0";
            }
        }

        // CREATE o UPDATE
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;
            Receta r = new Receta();
            r.RecetaId = Id;
            r.Nombre = txtNombre.Text;
            r.PaisOrigen = txtPais.Text;
            r.Ingredientes = txtIngredientes.Text;
            r.TiempoPreparacion = int.Parse(txtTiempo.Text);
            r.Vegetariana = rblVegetariana.SelectedValue == "1";
            try
            {
                bl.Guardar(r);
                Response.Redirect("Default.aspx?ok=1");
            }
            catch (ApplicationException ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
