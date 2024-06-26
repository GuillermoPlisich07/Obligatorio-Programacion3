﻿using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUModificarCliente : ICUModificar<DTOCliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUModificarCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOCliente t)
        {
            Repo.Update(MapperCliente.ToCliente(t));
        }
    }
}
