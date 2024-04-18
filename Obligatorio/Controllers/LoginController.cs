using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Obligatorio.Controllers
{
    public class LoginController : Controller
    {
        //private readonly LibreriaContext ctx;

        //public LoginController(LibreriaContext context)
        //{
        //    ctx = context;
        //}
        public ICULogin<Usuario> CULoginUsuario { get; set; }

        public LoginController(ICULogin<Usuario> cuLoginUsuario)
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
                HttpContext.Session.SetString("Nombre", usuario.nombre);
                HttpContext.Session.SetString("Apellido", usuario.apellido);
                HttpContext.Session.SetString("Email", usuario.email);
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
