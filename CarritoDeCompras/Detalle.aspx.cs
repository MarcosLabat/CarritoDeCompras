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
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public int indice { get; set; }
        public bool hayArt { get; set; }
        public Articulo articulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hayArt = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    articulos = (List<Articulo>)Session["ListaArticulos"];
                    int parametro = int.Parse(Request.QueryString["id"]);
                    indice = 0;
                    foreach (var articulo in articulos)
                    {

                        if (articulo.Id == parametro)
                        {
                            hayArt = true;
                            Session.Add("Articulo", articulo);
                            break;
                        }
                        indice++;
                    }

                }
                else
                {
                    lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
                }
            }else{
                hayArt = true;
            }

            if (hayArt){
                cargarArticulo();
            }else {
                lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoNegocio carrito = Session["Carrito"] as CarritoNegocio;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            int idArticulo = int.Parse(Request.QueryString["id"]);
            Articulo articulo = articuloNegocio.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;



            var masterPage = this.Master as SiteMaster;
            masterPage.ActualizarContenidoCarrito();
        }

        protected string cargarImagen(string url)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            if (imagenNegocio.VerificarUrlImagen(url))
            {
                return url;
            }

            return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
        }

        protected void cargarArticulo()
        {
            articulo = Session["Articulo"] as Articulo;
            tituloArticulo.Text = articulo.Nombre;
            descArticulo.Text = "Descpricion: " + articulo.Descripcion;
            marcaArticulo.Text = "Marca: " + articulo.Marca.ToString();
            categoriaArticulo.Text = "Categoria: " + articulo.Categoria.ToString(); ;
            precioArticulo.Text = "Precio: $" + articulo.Precio.ToString();
            cuotasArticulo.Text = "3 CUOTAS SIN INTERES DE $" + (articulo.Precio / 3).ToString("0.##") + " CADA UNA";
        }
    }
}