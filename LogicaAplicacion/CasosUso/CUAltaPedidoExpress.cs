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
    public class CUAltaPedidoExpress : ICUAlta<DTOPedidoExpress>
    {
        public IRepositorioPedidoExpress Repo { get; set; }

        public CUAltaPedidoExpress(IRepositorioPedidoExpress repo)
        {
            Repo = repo;
        }

        public void Alta(DTOPedidoExpress nuevo)
        {
            PedidoExpress aux = MapperPedido.ToPedidoExpress(nuevo);
            Repo.Add(aux);
        }
    }
}
