﻿using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedido(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Pedido item)
        {
            if (item != null )
            {
                Contexto.Pedidos.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos.Include(p => p.cliente).ToList();
        }

        public Pedido FindById(int id)
        {
            return Contexto.Pedidos
                .Include(p => p.cliente)
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
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        public void Anular(int id)
        {

            Pedido actualizar = Contexto.Pedidos.Find(id);
            actualizar.activo = false;
            if (actualizar != null)
            {
                Contexto.Pedidos.Update(actualizar);
                Contexto.SaveChanges();
            }
        }
    }
}
