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
    public partial class SiteMaster : MasterPage
    {
        public List<Marca> listaMarca { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                MarcaNegocio marca = new MarcaNegocio();
                CategoriaNegocio categoria = new CategoriaNegocio();
                listaMarca = marca.listar();
                listaCategoria = categoria.listar();
                repMarcas.DataSource = listaMarca;
                repCategorias.DataSource = listaCategoria;
                repMarcas.DataBind();
                repCategorias.DataBind();
            }
        }
    }
}