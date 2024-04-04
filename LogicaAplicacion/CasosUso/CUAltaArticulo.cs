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
    public class CUAltaArticulo : ICUAlta<Articulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUAltaArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public void Alta(Articulo value)
        {
            throw new NotImplementedException();
        }
    }
}
