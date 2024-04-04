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
    public class CUModificarLinea : ICUModificar<Linea>
    {
        public IRepositorioLinea Repo { get; set; }

        public CUModificarLinea(IRepositorioLinea repo)
        {
            Repo = repo;
        }

        public void Modificar(Linea t)
        {
            throw new NotImplementedException();
        }
    }
}
