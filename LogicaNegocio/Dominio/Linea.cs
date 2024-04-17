using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Lineas")]
    public class Linea
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El artículo es obligatorio.")]
        public Articulo articulo { get; set; }

        [Required(ErrorMessage = "La cantidad de unidades es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de unidades debe ser mayor que cero.")]
        public int cantUnidades { get; set; }

        [Required(ErrorMessage = "El precio unitario vigente es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal preUnitarioVigente { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
