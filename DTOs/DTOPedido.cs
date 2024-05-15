using LogicaNegocio.Dominio;
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

        [Required(ErrorMessage = "El cliente es obligatorio")]
        public Cliente cliente { get; set; }

        [Required(ErrorMessage = "Debe haber al menos una línea de pedido")]
        public List<Linea> lineas { get; set; }
        public decimal total { get; set; }
        public decimal IVA { get; set; }
        public decimal recarga { get; set; }
        public DateTime fechaPrometida { get; set; }

        [Required(ErrorMessage = "La distancia es obligatoria para los pedidos comunes")]
        public decimal? distancia { get; set; }

        [Range(1, 5, ErrorMessage = "El plazo de entrega debe estar entre 1 y 5 días")]
        public int? plazoDias { get; set; }
    }
}
