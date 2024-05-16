using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOPedidoSimple
    {
        public int id { get; set; }
        [DisplayName("Fecha Pedido")]
        public DateTime fechaPedido { get; set; }

        [DisplayName("Cliente")]
        public DTOCliente cliente { get; set; }
        [DisplayName("Total")]
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        [DisplayName("Recarga")]
        public decimal recarga { get; set; }
        [DisplayName("Fecha Prometida")]
        public DateTime fechaPrometida { get; set; }
    }
}
