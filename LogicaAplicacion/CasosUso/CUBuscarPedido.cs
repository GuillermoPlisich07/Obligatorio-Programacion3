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
    public class CUBuscarPedido : ICUBuscarPorId<DTOPedidoSimple>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUBuscarPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public DTOPedidoSimple Buscar(int id)
        {
            return MapperPedido.ToDTOPedidoSimpe(Repo.FindById(id));
        }
    }
}
