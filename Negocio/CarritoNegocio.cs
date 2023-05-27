using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoNegocio
    {
        private Carrito Carrito;

        public CarritoNegocio()
        {
            Carrito = new Carrito();
        }

        public void AgregarArticulo(Articulo articulo)
        {
            Carrito.Articulos.Add(articulo);
        }

        public void QuitarArticulo(Articulo articulo)
        {
            Carrito.Articulos.Remove(articulo);
        }

        public List<Articulo> ObtenerArticulos()
        {
            return Carrito.Articulos;
        }
    }
}
