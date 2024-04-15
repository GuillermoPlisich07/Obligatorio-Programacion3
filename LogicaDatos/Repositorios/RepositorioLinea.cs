using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioLinea : IRepositorioLinea
    {
       public LibreriaContext Contexto { get; set; }

        public RepositorioLinea(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Linea item)
        {
            if (item != null)
            {
                item.Validar();
                Contexto.Lineas.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Linea> FindAll()
        {
            return Contexto.Lineas.ToList();
        }

        public Linea FindById(int id)
        {
            return Contexto.Lineas
                .Where(Linea => Linea.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Linea aBorrar = Contexto.Lineas.Find(id);
            if (aBorrar != null)
            {
                Contexto.Lineas.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Linea obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

    }
}
