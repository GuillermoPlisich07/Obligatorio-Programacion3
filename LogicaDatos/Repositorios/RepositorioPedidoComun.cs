using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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
                try
                {
                    // Verificar si ya hay una instancia de Cliente rastreada y desadjuntarla
                    var existingCliente = Contexto.Clientes.Local.FirstOrDefault(c => c.id == item.cliente.id);
                    if (existingCliente != null)
                    {
                        Contexto.Entry(existingCliente).State = EntityState.Detached;
                    }

                    // Adjuntar la nueva instancia de Cliente
                    Contexto.Clientes.Attach(item.cliente);

                    Contexto.PedidoComunes.Add(item);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                
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
