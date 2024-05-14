using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOPedido
    {
        public int id { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        public DateTime fechaPedido { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        public Cliente cliente { get; set; }

        [Required(ErrorMessage = "Debe haber al menos una línea de pedido")]
        public List<Linea> lineas { get; set; }
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        public decimal recarga { get; set; }
        public DateTime fechaPrometida { get; set; }
    }
}
