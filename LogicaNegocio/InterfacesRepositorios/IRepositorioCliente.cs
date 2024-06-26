﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        List<Cliente> FindByRutOrMonto(string rut, string razonSocial,decimal monto);
    }
}
