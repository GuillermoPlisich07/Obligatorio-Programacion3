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
    public class CUBusquedaClientesMonto : ICUBuscarRutOMonto<DTOCliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBusquedaClientesMonto(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public List<DTOCliente> Buscar(string rut, string razonSocial, decimal monto)
        {
            return MapperCliente.ToListadoSimpleDTO(Repo.FindByRutOrMonto(rut, razonSocial, monto));
        }
    }
}
