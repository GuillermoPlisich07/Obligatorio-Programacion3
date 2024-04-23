using System.ComponentModel.DataAnnotations;


namespace Obligatorio.Models.UsuarioViewModels
{
    public class ListaUsuarioViewModel
    {

        [Required(ErrorMessage = "El email es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El email no tiene un formato válido")]
        public string email { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z' ]*[a-zA-Z]$", ErrorMessage = "El nombre no tiene un formato válido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z' ]*[a-zA-Z]$", ErrorMessage = "El apellido no tiene un formato válido")]
        public string apellido { get; set; }

    }
}
