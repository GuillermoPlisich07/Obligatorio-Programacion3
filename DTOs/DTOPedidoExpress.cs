using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOPedidoExpress
    {
        public int id { get; set; }
        public DTOCliente cliente { get; set; }
        public List<DTOLinea> lineas { get; set; }
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        public decimal recarga { get; set; }
        public DateTime fechaPrometida { get; set; }
        public int plazoDias { get; set; }
        public Boolean activo { get; set; }
    }
}
