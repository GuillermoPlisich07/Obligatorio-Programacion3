﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class PedidoComun : Pedido 
    {
        public decimal distancia { get; set; }

       public decimal kilometros { get; set; }
    }
}
