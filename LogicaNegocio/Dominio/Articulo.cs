using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Articulo : IValidable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre del artículo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre del artículo no puede tener más de 100 caracteres")]
        [Column("nombre")]
        [Index("IX_Nombre", IsUnique = true)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La descripción del artículo es obligatoria")]
        [MinLength(5, ErrorMessage = "La descripción del artículo debe tener al menos 5 caracteres")]
        [Column("descripcion")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El código del proveedor es obligatorio")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El código del proveedor debe tener 13 dígitos significativos")]
        [Column("codigoProveedor")]
        public int codigoProveedor { get; set; }

        [Column("precioPublico")]
        public PrecioArticulo precioPublico { get; set; }

        [Column("stock")]
        public int stock { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
