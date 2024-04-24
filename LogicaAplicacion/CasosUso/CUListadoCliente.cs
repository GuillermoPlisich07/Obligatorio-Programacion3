using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoCliente : ICUListado<DTOCliente>
    {
        
        public IRepositorioCliente Repo { get; set; }

        public CUListadoCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public List<DTOCliente> ObtenerListado()
        {
            return MapperCliente.ToListadoSimpleDTO(Repo.FindAll());
        }
    }
}
