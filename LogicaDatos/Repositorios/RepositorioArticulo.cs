using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioArticulo(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Articulo item)
        {
            if (item != null)
            {
                item.Validar();
                Contexto.Articulos.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Articulo> FindAll()
        {
            return Contexto.Articulos.ToList();
        }

        public Articulo FindById(int id)
        {
            return Contexto.Articulos
                .Where(Usuario => Usuario.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Articulo aBorrar = Contexto.Articulos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Articulos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Articulo obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
