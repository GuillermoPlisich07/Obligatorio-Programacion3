using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOCrearPedido
    {

        public List<DTOCliente> clientes { get; set; }

        public List<DTOArticulo> articulos { get; set; }

        public List<DTOLinea> lineas { get; set; }


        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int clienteId { get; set; }

        [Required(ErrorMessage = "La fecha prometida es requerida")]
        [DisplayName("Fecha Prometida")]
        public DateTime fechaPrometida { get; set; }


        [Required(ErrorMessage = "El tipo de pedido es obligatorio")]
        [DisplayName("Tipo Pedido")]
        public string tipoPedido { get; set; }


        [Required(ErrorMessage = "La distancia es obligatoria para los pedidos comunes")]
        [DisplayName("Distancia (km)")]
        public decimal? distancia { get; set; }


        [Range(1, 5, ErrorMessage = "El plazo de entrega debe estar entre 1 y 5 días")]
        [Required(ErrorMessage = "El plazo de entrega debe estar entre 1 y 5 días")]
        [DisplayName("Plazo (Dias)")]
        public int? plazoDias { get; set; }
    }
}
