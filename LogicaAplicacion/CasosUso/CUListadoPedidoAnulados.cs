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
    public class CUListadoPedidoAnulados : ICUListadoAnulados<DTOPedidoSimple>
    {
            public IRepositorioPedido Repo { get; set; }

            public CUListadoPedidoAnulados(IRepositorioPedido repo)
            {
                Repo = repo;
            }

        public List<DTOPedidoSimple> ObtenerListadoAnulados()
        {
            return MapperPedido.ToListadoPedidoSimpleDTO(Repo.FindAll().Where(e => e.activo == false).ToList());
        }
        }
}
