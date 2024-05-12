using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperCliente
    {
        public static Cliente ToCliente(DTOCliente cliente)
        {
            return new Cliente()
            {
              id = cliente.Id,
              RUT = cliente.RUT,
              razonSocial = cliente.RazonSocial,
              ciudad = cliente.Ciudad,  
              numPuerta = cliente.NumPuerta,
              calle = cliente.Calle,    
              distancia = cliente.Distancia,
            };
        }

        public static  DTOCliente ToDTOCliente(Cliente cliente)
        {

            return new DTOCliente()
            {
                Id = cliente.id,
                RUT = cliente.RUT,
                RazonSocial = cliente.razonSocial,
                Ciudad = cliente.ciudad,
                NumPuerta = cliente.numPuerta,
                Calle = cliente.calle,
                Distancia = cliente.distancia,
            };
        }
        public static List<DTOCliente> ToListadoSimpleDTO(List<Cliente> clientes)
        {
            return clientes.Select(clientes => ToDTOCliente(clientes)).ToList();
        }

    }
}
