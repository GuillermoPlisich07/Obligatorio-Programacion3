using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filtros;

namespace Obligatorio.Controllers
{
    public class LoginController : Controller
    {
        
        public ICULogin<DTOUsuario> CULoginUsuario { get; set; }

        public LoginController(ICULogin<DTOUsuario> cuLoginUsuario)
        {
            CULoginUsuario = cuLoginUsuario;
        }



        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string Email, string Password)
        {
            var usuario = CULoginUsuario.loguearse(Email, Password);

            if (usuario != null)
            {
                string nombre = usuario.nombre;
                string apellido = usuario.apellido;
                string email = usuario.email;
                HttpContext.Session.SetString("Nombre", nombre);
                HttpContext.Session.SetString("Apellido", apellido);
                HttpContext.Session.SetString("Email", email);
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login","Login");
        }



    }
}
