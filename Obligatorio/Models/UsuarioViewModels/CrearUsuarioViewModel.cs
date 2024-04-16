using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models.Usuario
{
    public class CrearUsuarioViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El email no tiene un formato válido")]
        [MaxLength(100)] // Longitud maxima de 100
        [Column(TypeName = "nvarchar(100)")] // Lo mismo pero para la base de datos
        public string email { get; set; }

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

        [Required(ErrorMessage = "La contraseña encriptada es obligatoria")]
        [MaxLength(100)] // Cambiar según la longitud máxima permitida en la base de datos
        [Column(TypeName = "nvarchar(100)")] // Cambiar según el tipo de datos de la columna en la base de datos
        public string passwordHash { get; set; }
    }
}
