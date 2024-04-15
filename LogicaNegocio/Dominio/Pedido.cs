using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pedido
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public Cliente cliente { get; set; }
        public List<Linea> lineas { get; set; }
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        public decimal recarga { get; set; }
        public DateTime fechaPrometida { get; set; }

        public void Validar()
        {
            // TODO
        }


    }
}
