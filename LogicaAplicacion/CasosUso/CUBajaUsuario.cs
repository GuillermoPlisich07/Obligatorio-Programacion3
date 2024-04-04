﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaUsuario : ICUBaja
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBajaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
        }
    }
}
