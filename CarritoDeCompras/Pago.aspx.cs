using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoDeCompras
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el carrito de la sesión
                CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;

                // Verificar si el carrito existe y contiene artículos
                if (carrito != null && carrito.ObtenerArticulos().Count > 0)
                {
                    // Enlazar el carrito al control Repeater
                    rptCarrito.DataSource = carrito.ObtenerArticulos();
                    rptCarrito.DataBind();
                }
                else
                {
                    // No hay artículos en el carrito, redirigir a la página principal
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int indice = Convert.ToInt32(btnEliminar.CommandArgument);
            EliminarArticulo(indice);
            MostrarCarrito();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            // Lógica para procesar el pago y redirigir a la página de confirmación
            // ...
        }

        private void MostrarCarrito()
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;
            if (carrito != null)
            {
                rptCarrito.DataSource = carrito.ObtenerArticulos();
                rptCarrito.DataBind();
            }
        }

        private void EliminarArticulo(int indice)
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;
            if (carrito != null)
            {
                List<Articulo> articulos = carrito.ObtenerArticulos();
                if (indice >= 0 && indice < articulos.Count)
                {
                    articulos.RemoveAt(indice);
                    Session["Carrito"] = carrito;
                }
            }
        }


        protected string ObtenerTotalCarrito()
        {
            // Obtener el carrito de la sesión
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;

            if (carrito != null)
            {
                decimal total = carrito.ObtenerTotal();
                return total.ToString("C");
            }

            return "$0.00";
        }
    }
}