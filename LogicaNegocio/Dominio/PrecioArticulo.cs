using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("PreciosArticulos")]
    public class PrecioArticulo
    {
        public int id { get; set; }
        public decimal precioPublico { get; set; }
        public DateTime fecha { get; set; }
    }

}
