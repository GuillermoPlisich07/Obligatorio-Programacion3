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
        public ICUListadoAnulados<DTOPedidoSimple> CUListadoPedidoAnulados { get; set; }

        public PedidoController(ICUListadoAnulados<DTOPedidoSimple> cUListadoPedido)
        {
            CUListadoPedidoAnulados = cUListadoPedido;
        }


        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get()
        {
                try
                {
                List<DTOPedidoSimple> pedidos = CUListadoPedidoAnulados.ObtenerListadoAnulados();

                var resultados = pedidos.OrderByDescending(p => p.fechaPedido)
                                .Select(p => new { 
                                         p.fechaPrometida,
                                         p.cliente.RazonSocial,
                                         p.total
                                        })
                                 .ToList();

                return Ok(resultados);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
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
