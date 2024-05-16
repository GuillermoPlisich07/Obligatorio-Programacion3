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
    public class CUListadoPedidoAnulados : ICUListado<DTOPedido>
    {
            public IRepositorioPedido Repo { get; set; }

            public CUListadoPedidoAnulados(IRepositorioPedido repo)
            {
                Repo = repo;
            }

            public List<DTOPedido> ObtenerListado()
            {
                return MapperPedido.ToListadoPedidoDTO(Repo.FindAll());
            }
        }
}
