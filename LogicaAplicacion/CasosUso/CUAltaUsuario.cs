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
    public class CUAltaUsuario : ICUAlta<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Alta(Usuario value)
        {
            throw new NotImplementedException();
        }
    }
}
