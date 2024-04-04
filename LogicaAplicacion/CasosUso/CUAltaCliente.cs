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
    public class CUAltaCliente : ICUAlta<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUAltaCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public void Alta(Cliente value)
        {
            throw new NotImplementedException();
        }
    }
}
