using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class PedidoComun : Pedido 
    {
        [Required(ErrorMessage = "La distancia es obligatoria para los pedidos comunes")]
        public decimal distancia { get; set; }

    }
}
