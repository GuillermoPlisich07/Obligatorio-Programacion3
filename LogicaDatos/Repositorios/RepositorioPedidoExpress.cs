using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedidoExpress : IRepositorioPedidoExpress
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedidoExpress(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(PedidoExpress item)
        {
            if (item != null)
            {
                Contexto.PedidosExpress.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<PedidoExpress> FindAll()
        {
            return Contexto.PedidosExpress.ToList();
        }

        public PedidoExpress FindById(int id)
        {
            return Contexto.PedidosExpress
                .Where(PedidosExpress => PedidosExpress.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            PedidoExpress aBorrar = Contexto.PedidosExpress.Find(id);
            if (aBorrar != null)
            {
                Contexto.PedidosExpress.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(PedidoExpress obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
