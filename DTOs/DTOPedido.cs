using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOPedido
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public DTOCliente cliente { get; set; }
        public List<DTOLinea> lineas { get; set; }
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        public DateTime fechaPrometida { get; set; }
        public Boolean activo { get; set; }
    }
}
