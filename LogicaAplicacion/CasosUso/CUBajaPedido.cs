using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaPedido : ICUBaja
    {
        public IRepositorioPedido Repo { get; set; }

        public CUBajaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            throw new NotImplementedException();
        }
    }
}
