using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOArticulo
    {
        [Key]
        public int id { get; set; }

        //[Required(ErrorMessage = "El nombre del artículo es obligatorio")]
        //[MinLength(10)]
        //[MaxLength(200, ErrorMessage = "El nombre del artículo no puede tener más de 100 caracteres")]
        public string nombre { get; set; }

        //[Required(ErrorMessage = "La descripción del artículo es obligatoria")]
        //[MinLength(5, ErrorMessage = "La descripción del artículo debe tener al menos 5 caracteres")]
        public string descripcion { get; set; }

        //[Required(ErrorMessage = "El código del proveedor es obligatorio")]
        //[StringLength(13, MinimumLength = 13, ErrorMessage = "El código del proveedor debe tener 13 dígitos significativos")]
        public int codigoProveedor { get; set; }

        public decimal precioPublico { get; set; }

        public int stock { get; set; }
    }
}
