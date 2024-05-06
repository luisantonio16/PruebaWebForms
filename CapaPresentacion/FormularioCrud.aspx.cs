using CapaNeocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormularioCrud : System.Web.UI.Page
    {
        private PersonaNeocio personaNegocio = new PersonaNeocio();
        public bool update = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerLista();
            btn.Enabled = false;
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            agregarPersona();
        }

        private void ObtenerLista()
        {
            try
            {
                dbGridView.DataSource = personaNegocio.ObtenerLista();
                dbGridView.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
        private void agregarPersona()
        {

            try
            {

                personaNegocio.Nombre = txtNombre.Value;
                personaNegocio.Apellido = txtApellido.Value;
                personaNegocio.Edad = Convert.ToInt32(txtEdad.Value);

                var resultado = personaNegocio.agregarPersona();

                if (resultado != null)
                {
                    result.InnerText = resultado.ToString();
                    ObtenerLista();
                    limpiarText();
                }
                else
                {
                    Response.Write("algo salio Mal!!!");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }


        }
        private void ActualizarPersona()
        {

            try
            {
                personaNegocio.estado = EstadoEntidad.Actualizar;
                personaNegocio.Id = Convert.ToInt32(LblId.Text);
                personaNegocio.Nombre = txtNombre.Value;
                personaNegocio.Apellido = txtApellido.Value;
                personaNegocio.Edad = Convert.ToInt32(txtEdad.Value);

                var resultado = personaNegocio.agregarPersona();

                if (resultado != null)
                {
                    result.InnerText = resultado.ToString();
                    ObtenerLista();
                    limpiarText();
                }
                else
                {
                    Response.Write("algo salio Mal!!!");
                }

            }
            catch (Exception)
            {

            }
            update = false;
            btn.Enabled = false;
            Button1.Enabled = true;


        }

        private void limpiarText()
        {
            txtNombre.Value = "";
            txtApellido.Value = "";
            txtEdad.Value = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            update = true;
            btn.Enabled = true;
            Button1.Enabled = false;

            LinkButton btnEditar = (LinkButton)sender;
            string id = btnEditar.CommandArgument;

            DataTable dt = personaNegocio.buscar(id);

            if (dt.Rows.Count > 0)
            {
                LblId.Text = id.ToString();
                txtNombre.Value = dt.Rows[0]["Nombre"].ToString();
                txtApellido.Value = dt.Rows[0]["Apellido"].ToString();
                txtEdad.Value = dt.Rows[0]["Edad"].ToString();


            }
            else
            {
                Response.Write("no hay registro");
            }



        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int id = Convert.ToInt32(btn.CommandArgument);

            personaNegocio.estado = EstadoEntidad.Eliminar;
            personaNegocio.Id = id;
            personaNegocio.agregarPersona();
            ObtenerLista();

        }



        protected void btn_Click1(object sender, EventArgs e)
        {
            ActualizarPersona();
        }
    }
}