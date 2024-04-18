using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }
        
        public RepositorioUsuario(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario nuevo)
        {
            if (nuevo != null)
            {
                nuevo.Validar();
                Contexto.Usuarios.Add(nuevo);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios
                .Where(Usuario => Usuario.id== id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Usuario aBorrar = Contexto.Usuarios.Find(id);
            if (aBorrar != null)
            {
                Contexto.Usuarios.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Usuario obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario Login(string email, string password)
        {
            Usuario user = FindByEmail(email);

            //if (user!=null && user.VerificarPassword(password))
            //{
            //    return user;
            //}
            if (user != null && user.passwordHash==password)
            {
                return user;
            }

            return null;
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios
                .Where(Usuario => Usuario.email == email)
                .SingleOrDefault();
        }
    }
}
