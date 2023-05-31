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
                CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;

                if (carrito != null && carrito.ObtenerArticulos().Count > 0)
                {
                    rptCarrito.DataSource = carrito.ObtenerArticulos();
                    rptCarrito.DataBind();
                }
                else
                {
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