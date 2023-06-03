using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Collections.Specialized.BitVector32;

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

        public void QuitarArticulo(int idArticulo)
        {
            Articulo articulo = Carrito.Articulos.FirstOrDefault(a => a.Id == idArticulo);
            if (articulo != null)
            {
                Carrito.Articulos.Remove(articulo);
            }
        }

        public List<Articulo> ObtenerArticulos()
        {
            return Carrito.Articulos;
        }

        public decimal ObtenerTotal()
        {
            decimal total = 0;

            foreach (var item in ObtenerArticulos())
            {
                total += item.Precio;
            }

            return total;
        }
    }
}
