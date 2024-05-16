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
    public class CUAltaPedidoComun : ICUAlta<DTOPedidoComun>
    {
        public IRepositorioPedidoComun Repo { get; set; }

        public CUAltaPedidoComun(IRepositorioPedidoComun repo)
        {
            Repo = repo;
        }

        public void Alta(DTOPedidoComun nuevo)
        {
            PedidoComun aux = MapperPedido.ToPedidoComun(nuevo);
            Repo.Add(aux);
        }
    }
}
