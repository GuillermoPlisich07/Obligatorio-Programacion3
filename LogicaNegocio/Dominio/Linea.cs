using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Lineas")]
    public class Linea
    {
        public int id { get; set; }
        public Articulo articulo { get; set; }
        public int cantUnidades { get; set; }
        public decimal preUnitarioVigente { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
