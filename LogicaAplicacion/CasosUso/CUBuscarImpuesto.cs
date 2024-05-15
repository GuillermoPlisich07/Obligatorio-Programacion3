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
  
    public class CUBuscarImpuesto : ICUBuscarPorId<DTOImpuesto>
    {
        public IRepositorioImpuesto Repo { get; set; }

        public CUBuscarImpuesto(IRepositorioImpuesto repo)
        {
            Repo = repo;
        }

        public DTOImpuesto Buscar(int id)
        {
            return MapperImpuesto.ToDTOImpuesto(Repo.FindById(id));
        }
    }
    
}
