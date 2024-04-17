using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioCliente(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Cliente item)
        {
            if (item != null)
            {
                Contexto.Clientes.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Cliente> FindAll()
        {
            return Contexto.Clientes.ToList();
        }

        public Cliente FindById(int id)
        {
            return Contexto.Clientes
                .Where(Usuario => Usuario.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Cliente aBorrar = Contexto.Clientes.Find(id);
            if (aBorrar != null)
            {
                Contexto.Clientes.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Cliente obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
