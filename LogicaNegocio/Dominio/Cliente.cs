using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Cliente")]
    public class Cliente
    {
        public int id { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        public string razonSocial { get; set; }

        [Required(ErrorMessage = "El RUT es obligatorio.")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "El RUT debe ser un número de 12 dígitos.")]
        public int RUT { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        public string ciudad { get; set; }

        [Required(ErrorMessage = "El número de puerta es obligatorio.")]
        public int numPuerta { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria.")]
        public string calle { get; set; }

        [Required(ErrorMessage = "La distancia es obligatoria.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal distancia { get; set; }
    }
}
