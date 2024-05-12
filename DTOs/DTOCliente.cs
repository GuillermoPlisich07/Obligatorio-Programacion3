using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOCliente
    {
        public int Id { get; set; }

        [DisplayName("Razon Social")]
        [Required(ErrorMessage = "La razón social es obligatoria.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El RUT es obligatorio.")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "El RUT debe ser un número de 12 dígitos.")]
        public int RUT { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        public string Ciudad { get; set; }

        [DisplayName("Numero de Puerta")]
        [Required(ErrorMessage = "El número de puerta es obligatorio.")]
        public int NumPuerta { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "La distancia es obligatoria.")]
        public decimal Distancia { get; set; }
    }
}
