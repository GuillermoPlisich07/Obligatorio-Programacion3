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
    public class CUListadoArticuloOrdenado : ICUListadoOrdenado<DTOArticulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUListadoArticuloOrdenado(IRepositorioArticulo repo)
        {
            Repo = repo;
        }
    
        public List<DTOArticulo> ObtenerListadoOrdenado()
        {
            return MapperArticulo.ToListadoOrdenado(Repo.FindAll());
        }

    }
}
