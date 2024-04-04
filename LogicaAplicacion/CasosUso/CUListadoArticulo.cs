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
    public class CUListadoArticulo : ICUListado<Articulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUListadoArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }
        public List<Articulo> ObtenerListado()
        {
            throw new NotImplementedException();
        }
    }
}
