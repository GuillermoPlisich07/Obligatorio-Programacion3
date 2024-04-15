using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    internal class RepositorioPedido : IRepositorioPedido
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedido(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Pedido item)
        {
            if (item != null)
            {
                item.Validar();
                Contexto.Pedidos.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos.ToList();
        }

        public Pedido FindById(int id)
        {
            return Contexto.Pedidos
                .Where(Pedido => Pedido.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Pedido aBorrar = Contexto.Pedidos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Pedidos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Pedido obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
