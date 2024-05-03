using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Migrations;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        public ICUAlta<DTOArticulo> CUAltaArticulo { get; set; }
        public ICUListadoOrdenado<DTOArticulo> CUListadoArticuloOrdenado { get; set; }

        public ArticuloController(ICUAlta<DTOArticulo> cUAltaArticulo, ICUListadoOrdenado<DTOArticulo> cUListadoArticulo)
        {
            CUAltaArticulo = cUAltaArticulo;
            CUListadoArticuloOrdenado = cUListadoArticulo;
        }

        // GET: api/<ArticuloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<DTOArticulo> articulos = CUListadoArticuloOrdenado.ObtenerListadoOrdenado();
                 return Ok(articulos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
         
            return "value";
        }


        // POST api/<ArticuloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
