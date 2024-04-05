using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{

    public class UsuarioController : Controller
    {

        public ICUAlta<Usuario> CUAltaUsuario { get; set; }
        public ICUBaja CUBajaUsuario { get; set; }
        public ICUModificar<Usuario> CUModificarUsuario { get; set; }

        public UsuarioController(ICUAlta<Usuario> cuAltaUsuario, ICUBaja cuBajaUsuario, ICUModificar<Usuario> cuModificarUsuario)
        {
            CUAltaUsuario = cuAltaUsuario;
            CUBajaUsuario = cuBajaUsuario;
            CUModificarUsuario = cuModificarUsuario;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
