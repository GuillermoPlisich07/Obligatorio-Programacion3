using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class PedidoExpress : Pedido
    {
        [Range(1, 5, ErrorMessage = "El plazo de entrega debe estar entre 1 y 5 días")]
        public int plazoDias { get; set; }
    }
}
