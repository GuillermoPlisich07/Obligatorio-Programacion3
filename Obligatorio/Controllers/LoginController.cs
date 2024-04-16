using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class LoginController : Controller
    {
        private readonly LibreriaContext ctx;

        public LoginController(LibreriaContext context)
        {
            ctx = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombreUsuario, string contraseña)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.nombre == nombreUsuario && u.password == contraseña);

            if (usuario != null)
            {
                // Usuario autenticado, redirige a la página principal
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Autenticación fallida, muestra un mensaje de error
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                return View();
            }
        }
    }
}
