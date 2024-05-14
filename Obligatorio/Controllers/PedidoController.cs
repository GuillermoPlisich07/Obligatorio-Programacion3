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
    public class PedidoController : Controller
    {
        ICUAlta<DTOPedido> CUAltaPedido { get; set; }
        ICUListado<DTOPedido> CUListadoPedido { get; set; }
        ICUBaja CUBajaPedido { get; set; }  

        public PedidoController(ICUAlta<DTOPedido> cUAltaPedido, ICUListado<DTOPedido> cUListadoPedido, ICUBaja cUBajaPedido)
        {
            CUAltaPedido = cUAltaPedido;
            CUListadoPedido = cUListadoPedido;
            CUBajaPedido = cUBajaPedido;
        }



        [User]
        // GET: PedidoController
        public ActionResult Index()
        {
            List<DTOPedido> pedidos = CUListadoPedido.ObtenerListado();
            return View(pedidos);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOPedido nuevo)
        {
            {
                try
                {
                    CUAltaPedido.Alta(nuevo);
                    return RedirectToAction(nameof(Index));
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta del pedido";
                }

                return View(nuevo);
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
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
