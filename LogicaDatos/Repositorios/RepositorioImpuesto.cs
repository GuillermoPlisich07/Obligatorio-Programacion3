using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioImpuesto : IRepositorioImpuesto
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioImpuesto(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Impuesto item)
        {
            if (item != null)
            {
                Contexto.Impuestos.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Impuesto> FindAll()
        {
            return Contexto.Impuestos.ToList();
        }

        public Impuesto FindById(int id)
        {
            return Contexto.Impuestos
                .Where(e => e.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Impuesto aBorrar = Contexto.Impuestos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Impuestos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Impuesto obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
