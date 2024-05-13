using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
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
