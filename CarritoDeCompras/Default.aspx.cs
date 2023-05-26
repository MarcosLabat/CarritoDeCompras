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
            ListaArticulos = negocio.listar();
            if (!IsPostBack)
            {
                repArticulos.DataSource = ListaArticulos;
                repArticulos.DataBind();
                Session.Add("ListaArticulos", ListaArticulos);
            }
        }
    }
}