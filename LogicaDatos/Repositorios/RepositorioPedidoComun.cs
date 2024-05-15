using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedidoComun : IRepositorioPedidoComun
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedidoComun(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(PedidoComun item)
        {
            if (item != null)
            {
                Contexto.PedidoComunes.Add(item);
                Contexto.SaveChanges();
            }
        }

        public List<PedidoComun> FindAll()
        {
            return Contexto.PedidoComunes.ToList();
        }

        public PedidoComun FindById(int id)
        {
            return Contexto.PedidoComunes
                .Where(Pedido => Pedido.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            PedidoComun aBorrar = Contexto.PedidoComunes.Find(id);
            if (aBorrar != null)
            {
                Contexto.PedidoComunes.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(PedidoComun obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
