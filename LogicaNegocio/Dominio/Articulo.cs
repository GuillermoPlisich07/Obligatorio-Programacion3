using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Articulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int codigoProveedor { get; set; }
        public PrecioArticulo precioPublico { get; set; }
        public int stock { get; set; }

    }
}
