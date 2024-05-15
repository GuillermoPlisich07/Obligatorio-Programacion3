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
    public class CUModificarImpuesto : ICUModificar<DTOImpuesto>
    {
        public IRepositorioImpuesto Repo { get; set; }

        public CUModificarImpuesto(IRepositorioImpuesto repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOImpuesto t)
        {
            Repo.Update(MapperImpuesto.ToImpuesto(t));
        }
    }
}
