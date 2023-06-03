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
    public partial class Filtro : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo { get; set; }
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                if (Request.QueryString["id"] == null || Request.QueryString["Tipo"] == null){
                    lblTitulo.Text = "NO SE A SELECCIONADO NADA";
                    return;
                }
                if (Request.QueryString["Tipo"] == "Marca"){
                    listaArticulo = articulo.listarPorMarca(int.Parse(Request.QueryString["id"]));
                    if (listaArticulo.Count == 0)
                    {
                        lblTitulo.Text = "NO HAY ARTICULOS DISPONIBLES CON LA MARCA SELECCIONADA";
                    }
                    else
                    {
                        lblTitulo.Text = "ARTICULOS PARA LA MARCA " + "'" + listaArticulo[0].Marca.ToString() + "'";
                        rptArticulos.DataSource = listaArticulo;
                        rptArticulos.DataBind();
                    }
                }
                else if(Request.QueryString["Tipo"] == "Categoria"){
                    listaArticulo = articulo.listarPorCategoria(int.Parse(Request.QueryString["id"]));
                    if (listaArticulo.Count == 0)
                    {
                        lblTitulo.Text = "NO HAY ARTICULOS DISPONIBLES CON LA CATEGORIA SELECCIONADA";
                    }
                    else
                    {
                        lblTitulo.Text = "ARTICULOS PARA LA CATEGORIA " + "'" + listaArticulo[0].Categoria.ToString() + "'";
                        rptArticulos.DataSource = listaArticulo;
                        rptArticulos.DataBind();
                    }
                }
                else{
                    lblTitulo.Text = "'TIPO' SELECCIONADO ERRONEO";
                }
                
            }
        }

        public string cargarImagen(string url)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            if (imagenNegocio.VerificarUrlImagen(url))
            {
                return string.Format("<img src='{0}' class='card-img-top' />", url);
            }

            return "<img src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg' class='card-img-top' />";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;

            Button btnAgregar = (Button)sender;
            int idArticulo = int.Parse(btnAgregar.CommandArgument);
            Articulo articulo = articuloNegocio.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;



            var masterPage = this.Master as SiteMaster;
            masterPage.ActualizarContenidoCarrito();
        }
    }
}