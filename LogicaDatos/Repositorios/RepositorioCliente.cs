using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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

        public List<Cliente> FindByRutOrMonto(string rut, string razonSocial, decimal monto)
        {
            return Contexto.Clientes
                    .Join(Contexto.Pedidos,
                          cliente => cliente.id,
                          pedido => pedido.cliente.id,
                          (cliente, pedido) => new { Cliente = cliente, Pedido = pedido })
                    .Where(cp => rut == null || cp.Cliente.RUT == int.Parse(rut))
                    .Where(cp => rut == razonSocial || cp.Cliente.razonSocial == razonSocial)
                    .Where(cp => monto == null || cp.Pedido.total >= monto)
                    .Select(cp => cp.Cliente)
                    .ToList();
        }

    }
}
