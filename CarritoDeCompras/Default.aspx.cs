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
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            if (!IsPostBack)
            {
                ListaArticulos = negocio.listar();
                Session.Add("ListaArticulos", ListaArticulos);
            }
        }

        public void cargarImagen(string url)
        {
            imgArticulo.ImageUrl = url;
        }
    }
}