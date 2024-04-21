using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Migrations;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filtros;

namespace Obligatorio.Controllers
{
    public class ClienteController : Controller
    {
        public ICUModificar<Cliente> CUModificarCliente { get; set; }
        public ICUBaja CUBajaCliente { get; set; }
        public ICUAlta<Cliente> CUAltaCliente { get; set; }
        public ICUBuscarPorId<Cliente> CUBuscarCliente { get; set; } 
        public ICUBuscarRutOMonto<Cliente> CUBuscarRutOMonto { get; set; } 

        public ICUListado<Cliente> CUListadoCliente { get; set; }

        public ClienteController(ICUModificar<Cliente> cUModificarCliente, ICUBaja cUBajaCliente, ICUAlta<Cliente> cUAltaCliente, 
                                ICUBuscarPorId<Cliente> cUBuscarCliente, ICUListado<Cliente> cUListadoCliente, ICUBuscarRutOMonto<Cliente> cUBuscarRutOMonto)
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
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult BusquedaClientesMonto()
        {
            List<Cliente> temas = CUListadoCliente.ObtenerListado();
            return View(temas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaClientesMonto(string rut, string razonSocial, int monto)
        {
            try
            {
                List<Cliente> temas = CUBuscarRutOMonto.Buscar(rut, razonSocial,monto);
                return View(temas);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }

            return View();
        }


        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
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
            return View();
        }

        // POST: ClienteController/Delete/5
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


        [HttpPost]
        public ActionResult BusquedaClientes(string BusquedaClientes, IFormCollection collection)
        {
            return View();
        }


    }
}
