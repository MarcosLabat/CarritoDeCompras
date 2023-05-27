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
        ArticuloNegocio articuloNegocio;
        CarritoNegocio carrito;

        public _Default()
        {
            articuloNegocio = new ArticuloNegocio();
            carrito = new CarritoNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ListaArticulos = articuloNegocio.listar();
                Session.Add("ListaArticulos", ListaArticulos);
            }

            ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
            Session["Carrito"] = carrito.ObtenerArticulos() ;
        }

        public void cargarImagen(string url)
        {
            imgArticulo.ImageUrl = url;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(btnAgregar.CommandArgument);
            Articulo articulo = articuloNegocio.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
        }
    }
}