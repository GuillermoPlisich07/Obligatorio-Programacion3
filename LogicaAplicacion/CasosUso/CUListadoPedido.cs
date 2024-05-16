using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoPedido : ICUListado<DTOPedidoSimple>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUListadoPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public List<DTOPedidoSimple> ObtenerListado()
        {
            return MapperPedido.ToListadoPedidoSimpleDTO(Repo.FindAll());
        }
    }
}
