using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filtros;

namespace Obligatorio.Controllers
{
    public class ClienteController : Controller
    {
        public ICUModificar<DTOCliente> CUModificarCliente { get; set; }
        public ICUBaja CUBajaCliente { get; set; }
        public ICUAlta<DTOCliente> CUAltaCliente { get; set; }
        public ICUBuscarPorId<DTOCliente> CUBuscarCliente { get; set; } 
        public ICUBuscarRutOMonto<DTOCliente> CUBuscarRutOMonto { get; set; } 

        public ICUListado<DTOCliente> CUListadoCliente { get; set; }

        public ClienteController(ICUModificar<DTOCliente> cUModificarCliente, ICUBaja cUBajaCliente, ICUAlta<DTOCliente> cUAltaCliente, 
                                ICUBuscarPorId<DTOCliente> cUBuscarCliente, ICUListado<DTOCliente> cUListadoCliente, ICUBuscarRutOMonto<DTOCliente> cUBuscarRutOMonto)
        {
            CUModificarCliente = cUModificarCliente;
            CUBajaCliente = cUBajaCliente;
            CUAltaCliente = cUAltaCliente;
            CUBuscarCliente = cUBuscarCliente;
            CUListadoCliente = cUListadoCliente;
            CUBuscarRutOMonto = cUBuscarRutOMonto;
        }
        [User]
        // GET: ClienteController
        public ActionResult Index()
        {
            List<DTOCliente> clientes = CUListadoCliente.ObtenerListado();
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult BusquedaClientesMonto()
        {
            List<DTOCliente> temas = CUListadoCliente.ObtenerListado();
            return View(temas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaClientesMonto(string rut, string razonSocial, int monto)
        {
            try
            {
                List<DTOCliente> temas = CUBuscarRutOMonto.Buscar(rut, razonSocial,monto);
                return View(temas);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }

            return View();
        }


        // GET: ClienteController/Create
        public ActionResult Create(DTOCliente nuevo)
        {
            try
            {
                CUAltaCliente.Alta(nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta del cliente";
            }

            return View(nuevo);
        }

        // POST: ClienteController/Create
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            DTOCliente t = CUBuscarCliente.Buscar(id);
            return View(t);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CUBajaCliente.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
