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
    public class CUAltaPedido : ICUAlta<DTOPedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAltaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void Alta(DTOPedido nuevo)
        {
            Repo.Add(MapperPedido.ToPedido(nuevo));
        }
    }
}
