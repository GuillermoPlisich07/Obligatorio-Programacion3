using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class LineaController : Controller
    {
        public ICUAlta<Linea> CUAltaLinea { get; set; }
        public ICUBaja CUBajaLinea { get; set; }
        public ICUModificar<Linea> CUModificarLinea { get; set; }

        public LineaController ( ICUAlta<Linea> cUAltaLinea, ICUBaja cUBajaLinea, ICUModificar<Linea> cUModificarLinea)
        {
            CUAltaLinea = cUAltaLinea;
            CUBajaLinea = cUBajaLinea;
            CUModificarLinea = cUModificarLinea;
        }




        // GET: LineaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LineaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaController/Create
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

        // GET: LineaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaController/Edit/5
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

        // GET: LineaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineaController/Delete/5
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
