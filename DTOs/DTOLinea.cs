using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOLinea
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El artículo es obligatorio.")]
        public DTOArticulo articulo { get; set; }

        [Required(ErrorMessage = "La cantidad de unidades es obligatoria.")]
        public int cantUnidades { get; set; }

        [Required(ErrorMessage = "El precio unitario vigente es obligatorio.")]
        public decimal preUnitarioVigente { get; set; }

    }
}
