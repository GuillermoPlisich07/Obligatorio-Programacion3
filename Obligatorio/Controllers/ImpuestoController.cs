using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filtros;

namespace Obligatorio.Controllers
{
    public class ImpuestoController : Controller
    {

        public ICUModificar<DTOImpuesto> CUModificarImpuesto{ get; set; }
        public ICUBuscarPorId<DTOImpuesto> CUBuscarImpuesto { get; set; }

        public ImpuestoController(ICUModificar<DTOImpuesto> cuModificarImpuesto, ICUBuscarPorId<DTOImpuesto> cUBuscarImpuesto)
        {
            CUModificarImpuesto = cuModificarImpuesto;
            CUBuscarImpuesto = cUBuscarImpuesto;
        }

        // GET: ImpuestoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImpuestoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImpuestoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImpuestoController/Create
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

        // GET: ImpuestoController/Edit/5
        public ActionResult Edit(int id)
        {
            DTOImpuesto imp = CUBuscarImpuesto.Buscar(id);
            return View(imp);
        }

        // POST: ImpuestoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DTOImpuesto imp)
        {
            try
            {
                imp.id = id;
                CUModificarImpuesto.Modificar(imp);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;

            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar la modificación";
            }

            return View();
        }

        // GET: ImpuestoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImpuestoController/Delete/5
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
