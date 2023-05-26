using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public List<Articulo> Articulos { get; set; }

        public Carrito() 
        {
            Articulos = new List<Articulo>();
        }
    }
}
