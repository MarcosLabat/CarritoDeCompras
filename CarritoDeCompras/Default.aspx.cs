using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CarritoDeCompras
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        ArticuloNegocio articuloNegocio;

        public _Default()
        {
            articuloNegocio = new ArticuloNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ListaArticulos = articuloNegocio.listar();
                Session.Add("ListaArticulos", ListaArticulos);

            }

            ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
        }

        public void cargarImagen(string url)
        {
            if (VerificarUrlImagen(url))
            {
                imgArticulo.ImageUrl = url;
            }
            else
            {
                imgArticulo.ImageUrl = "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;
            int idArticulo = int.Parse(btnAgregar.CommandArgument);
            Articulo articulo = articuloNegocio.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;

        }

        private bool VerificarUrlImagen(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "HEAD";
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        return response.StatusCode == HttpStatusCode.OK;
                    }
                }
                catch (WebException)
                {
                    return false;
                }
            }

            return false;
        }
    }
}