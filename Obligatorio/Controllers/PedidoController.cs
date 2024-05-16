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
        public ICUBaja CUBajaPedido { get; set; }
        public ICUAlta<DTOPedidoExpress> CUAltaPedidoExpress {  get; set; }
        public ICUAlta<DTOPedidoComun> CUAltaPedidoComun { get; set; }
        public ICUListado<DTOCliente> CUListadoCliente { get; set; }
        public ICUListado<DTOArticulo> CUListadoArticulo { get; set; }
        public ICUBuscarPorId<DTOCliente> CUBuscarCliente { get; set; }
        public ICUBuscarPorId<DTOArticulo> CUBuscarArticulo { get; set; }
        public ICUBuscarPorId<DTOImpuesto> CUBuscarImpuesto { get; set; }
        public ICUListado<DTOPedidoSimple> CUListadoPedidoSimple{ get; set; }


        public PedidoController(ICUBaja cUBajaPedido, ICUListado<DTOCliente> cUListadoCliente, ICUListado<DTOArticulo> cUListadoArticulo,
            ICUBuscarPorId<DTOCliente> cUBuscarCliente, ICUBuscarPorId<DTOArticulo> cUBuscarArticulo, ICUBuscarPorId<DTOImpuesto> cUBuscarImpuesto,
            ICUAlta<DTOPedidoExpress> cUAltaPedidoExpress, ICUAlta<DTOPedidoComun> cUAltaPedidoComun,
            ICUListado<DTOPedidoSimple> cUListadoPedidoSimple)
        {
            CUBajaPedido = cUBajaPedido;
            CUListadoCliente = cUListadoCliente;
            CUListadoArticulo = cUListadoArticulo;
            CUBuscarCliente = cUBuscarCliente;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarImpuesto = cUBuscarImpuesto;
            CUAltaPedidoExpress = cUAltaPedidoExpress;
            CUAltaPedidoComun = cUAltaPedidoComun;
            CUListadoPedidoSimple = cUListadoPedidoSimple;
        }



        [User]
        // GET: PedidoController
        public ActionResult Index()
        {
            List<DTOPedidoSimple> lista = CUListadoPedidoSimple.ObtenerListado().ToList();
            return View(lista);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            DTOCrearPedido modelo = new DTOCrearPedido();
            modelo.clientes = CUListadoCliente.ObtenerListado();
            modelo.articulos = CUListadoArticulo.ObtenerListado();
            return View(modelo);
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOCrearPedido nuevo)
        {
            ViewBag.Mensaje = null;
            try
            {
                DTOCliente existeCliente = CUBuscarCliente.Buscar(nuevo.clienteId);

                if (existeCliente!=null)
                {

                    DateTime fechaPrometida = nuevo.fechaPrometida;
                    DateTime hoy = DateTime.Now;
                    if (fechaPrometida.Year >= hoy.Year && fechaPrometida.Month >= hoy.Month && fechaPrometida.Day >= hoy.Day)
                    {
                        if (nuevo.lineas != null)
                        {
                            decimal totalAcumulado=0;
                            DTOPedidoComun dTOPedidoComun = new DTOPedidoComun();
                            DTOPedidoExpress dTOPedidoExpress = new DTOPedidoExpress();

                            List<DTOLinea> lineas = nuevo.lineas;
                            List<DTOLinea> lineasAgregar = new List<DTOLinea>();
                            foreach (var linea in lineas )
                            {
                                DTOArticulo articulo = CUBuscarArticulo.Buscar(linea.articulo.Id);
                                if (articulo!=null && (articulo.Stock-linea.cantUnidades)>=0)
                                {
                                    DTOLinea nuevLinea= new DTOLinea();
                                    nuevLinea.articulo = articulo;
                                    nuevLinea.cantUnidades = linea.cantUnidades;
                                    nuevLinea.preUnitarioVigente = linea.preUnitarioVigente;
                                    totalAcumulado += nuevLinea.cantUnidades * nuevLinea.preUnitarioVigente;
                                    lineasAgregar.Add(nuevLinea);                                
                                }
                                else
                                {
                                    throw new DatosInvalidosException("Hay un articulo que no se encuentra en la lista o la peticion supera el stock");
                                }
                            }

                            if (nuevo.tipoPedido=="express")
                            {
                                if (nuevo.plazoDias!=null)
                                {
                                    int? plazoDias = nuevo.plazoDias;
                                    DTOPedidoExpress pedido = new DTOPedidoExpress();
                                    pedido.plazoDias = (int)plazoDias;
                                    pedido.activo = true;
                                    pedido.fechaPrometida = fechaPrometida;
                                    pedido.cliente = existeCliente;
                                    pedido.lineas = lineasAgregar;

                                    DTOImpuesto imp = CUBuscarImpuesto.Buscar(1);
                                    pedido.IVA = imp.IVA;
                                    if (fechaPrometida >= hoy && fechaPrometida <= hoy.AddDays(5))
                                    {
                                        if (fechaPrometida.Year == hoy.Year && fechaPrometida.Month == hoy.Month && fechaPrometida.Day == hoy.Day)
                                        {
                                            pedido.recarga = imp.entregaExpressMismoDia;
                                        }
                                        else
                                        {
                                            pedido.recarga = imp.entregaExpressComun;
                                        }
                                    }
                                    else
                                    {
                                        throw new DatosInvalidosException("La fecha prometida mayor a 5 dias");
                                    }

                                    decimal recargo = totalAcumulado * (pedido.recarga / 100);

                                    decimal IVA = totalAcumulado / (1 + (pedido.IVA / 100));

                                    pedido.total = totalAcumulado + recargo + IVA;


                                    dTOPedidoExpress = pedido;
                                    CUAltaPedidoExpress.Alta(pedido);

                                }
                                else
                                {
                                    throw new DatosInvalidosException("Hubo un error a la hora de cargar el plazo de entrega");
                                }
                            }
                            else
                            {
                                if (nuevo.distancia != null)
                                {
                                    decimal? distancia = nuevo.distancia;
                                    DTOPedidoComun pedido = new DTOPedidoComun();
                                    pedido.distancia = (decimal)distancia;
                                    pedido.activo = true;
                                    pedido.fechaPrometida = fechaPrometida;
                                    pedido.cliente = existeCliente;
                                    pedido.lineas = lineasAgregar;

                                    DTOImpuesto imp = CUBuscarImpuesto.Buscar(1);
                                    pedido.IVA = imp.IVA;
                                    decimal recargo = 0;
                                    if (pedido.distancia>100)
                                    {
                                        pedido.recarga = imp.entregaComunMayorCien;
                                        recargo = totalAcumulado * (pedido.recarga / 100);
                                    }
                                    
                                    decimal IVA = totalAcumulado / (1 + (pedido.IVA / 100));

                                    pedido.total = totalAcumulado + recargo + IVA;

                                    dTOPedidoComun = pedido;
                                    CUAltaPedidoComun.Alta(pedido);
                                    
                                }
                                else
                                {
                                    throw new DatosInvalidosException("Hubo un error a la hora de cargar la distancia del pedido");
                                }
                                
                            }

                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            throw new DatosInvalidosException("Se debe ingresar al menos un articulo para realizar el pedido!");
                        }
                    }
                    else
                    {
                        throw new DatosInvalidosException("La fecha que ingreso tiene que ser mayo o igual a la fecha de hoy!");
                    }
                }
                else
                {
                    throw new DatosInvalidosException("El usuario que selecciono no esta registrado!");
                }
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex;
            }


            
            nuevo.clientes = CUListadoCliente.ObtenerListado();
            nuevo.articulos = CUListadoArticulo.ObtenerListado();
            return View(nuevo);
            
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
