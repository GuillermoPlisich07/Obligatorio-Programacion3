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
              id = cliente.id,
              RUT = cliente.RUT,
              razonSocial = cliente.razonSocial,
            };
        }

        public static  DTOCliente ToDTOCliente(Cliente cliente)
        {

            return new DTOCliente()
            {
                id = cliente.id,
                RUT = cliente.RUT
            };
        }
        public static List<DTOCliente> ToListadoSimpleDTO(List<Cliente> clientes)
        {
            return clientes.Select(clientes => ToDTOCliente(clientes)).ToList();
        }

        //public static List<DTOCliente> ToFindByIdDTO(List<Cliente> clientes, int id)
        //{
        //    return clientes
        //        .Where(cliente => cliente.id == id) // Filtrar por ID
        //        .Select(cliente => ToDTOCliente(cliente)) // Convertir a DTOCliente
        //        .ToList(); 
        //}
    }
}
