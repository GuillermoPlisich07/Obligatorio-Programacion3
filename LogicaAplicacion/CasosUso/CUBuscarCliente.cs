﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarCliente : ICUBuscarPorId<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public Cliente Buscar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
