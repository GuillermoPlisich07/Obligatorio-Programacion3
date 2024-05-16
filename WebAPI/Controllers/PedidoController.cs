using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public ICUListado<DTOPedido> CUListadoPedido { get; set; }

        public PedidoController(ICUListado<DTOPedido> cUListadoPedido)
        {
            CUListadoPedido = cUListadoPedido;
        }


        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get(DTOPedido pedido)
        {
            if (pedido.activo == false)
            {
                try
                {
                    List<DTOPedido> pedidos = CUListadoPedido.ObtenerListado();

                    // Ordenar la lista de pedidos por fecha de pedido de forma descendente
                    pedidos = pedidos.OrderByDescending(p => p.fechaPedido).ToList();

                    return Ok(pedidos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                throw new Exception("No hay ningún pedido anulado");
            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
