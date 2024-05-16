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
    public class CUAnularPedido : ICUAnular
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAnularPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void Anular(int id)
        {
            Repo.Anular(id);
        }
    }
}
