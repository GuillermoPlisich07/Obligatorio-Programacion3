using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models.Usuario
{
    public class ModificarUsuarioViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z' ]*[a-zA-Z]$", ErrorMessage = "El nombre no tiene un formato válido")]
        [MaxLength(50)] // Cambiar según la longitud máxima permitida en la base de datos
        [Column(TypeName = "nvarchar(50)")] // Cambiar según el tipo de datos de la columna en la base de datos
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z' ]*[a-zA-Z]$", ErrorMessage = "El apellido no tiene un formato válido")]
        [MaxLength(50)] // Cambiar según la longitud máxima permitida en la base de datos
        [Column(TypeName = "nvarchar(50)")] // Cambiar según el tipo de datos de la columna en la base de datos
        public string apellido { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;¡!])[A-Za-z\d.,;¡!]+$", ErrorMessage = "La contraseña no cumple con los requisitos mínimos")]
        [NotMapped] // No mapear este campo a la base de datos
        public string password { get; set; }
    }
}
