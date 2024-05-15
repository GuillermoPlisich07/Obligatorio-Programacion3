using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Impuesto
    {
        public int id { get; set; }

        public decimal IVA { get; set; }

        public decimal entregaExpressComun { get; set; }

        public decimal entregaExpressMismoDia { get; set; }

        public decimal entregaComunMayorCien { get; set; }


    }
}
