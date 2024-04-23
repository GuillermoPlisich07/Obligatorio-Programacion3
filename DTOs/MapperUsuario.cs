using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuario
    {
        public static Usuario ToUsuario(DTOUsuario usuario)
        {
            return new Usuario()
            {
                id = usuario.Id,
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                email = usuario.email,
                password = usuario.password,
            }; 
        }

        public static DTOUsuario ToDTOUsuario(Usuario usuario)
        {
            
            return new DTOUsuario()
            {
                Id = usuario.id,
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                email = usuario.email,
            };
        }

        public static List<DTOUsuario> ToListadoUsuarioDTO(List<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ToDTOUsuario(usuario)).ToList();
        }

    }
}
