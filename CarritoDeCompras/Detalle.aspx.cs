using Dominio;
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
                            break;
                        }
                        indice++;
                    }
                    if (hayArt)
                    {
                        tituloArticulo.Text = articulos[indice].Nombre;
                        descArticulo.Text = "Descpricion: " + articulos[indice].Descripcion;
                        marcaArticulo.Text = "Marca: "+ articulos[indice].Marca.ToString();
                        categoriaArticulo.Text = "Categoria: " +  articulos[indice].Categoria.ToString(); ;
                        precioArticulo.Text = "Precio: " + articulos[indice].Precio.ToString() + "$";
                        cuotasArticulo.Text = "3 CUOTAS SIN INTERES DE " + (articulos[indice].Precio / 3).ToString("0.##") + "$ CADA UNA";
                    }
                    else
                    {
                        lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
                    }

                }
                else
                {
                    lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
                }
            }
        }
    }
}