using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        [Column("FechaPedido")]
        public DateTime fechaPedido { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        [ForeignKey("idCliente")] 
        public Cliente cliente { get; set; }

        [Required(ErrorMessage = "Debe haber al menos una línea de pedido")]
        public List<Linea> lineas { get; set; }

        [Column("total")]
        public decimal total { get; set; }

        [Column("IVA")]
        public decimal IVA { get; set; }

        [Column("recargo")]
        public decimal recarga { get; set; }

        [Column("fechaPrometida")]
        public DateTime fechaPrometida { get; set; }



    }
}
