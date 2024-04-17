using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("PedidoComun")]
    public class PedidoComun : Pedido 
    {
        [Required(ErrorMessage = "La distancia es obligatoria para los pedidos comunes")]
        [Column("distancia", TypeName = "decimal(18, 2)")]
        public decimal distancia { get; set; }

    }
}
