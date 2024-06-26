﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperPedido
    {
        //Comun
        public static PedidoComun ToPedidoComun(DTOPedidoComun pedido)
        {
            PedidoComun nuevo = new PedidoComun()
            {
                cliente = MapperCliente.ToCliente(pedido.cliente),
                lineas = MapperLinea.ToListadoLinea(pedido.lineas),
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,
                distancia = pedido.distancia,
                activo = pedido.activo
            };
            return nuevo;
        }

        public static DTOPedidoComun ToDTOPedidoComun(PedidoComun pedido)
        {

            if (pedido != null)
            {
                
                return new DTOPedidoComun()
                {
                    id = pedido.id,
                    cliente = MapperCliente.ToDTOCliente(pedido.cliente),
                    lineas = MapperLinea.ToListadoLineaDTO(pedido.lineas),
                    total = pedido.total,
                    IVA = pedido.IVA,
                    recarga = pedido.recarga,
                    fechaPrometida = pedido.fechaPrometida,
                    distancia = pedido.distancia,
                    activo = pedido.activo
                    
                };
            }
            return null;
        }

        public static List<PedidoComun> ToListadoPedidoComun(List<DTOPedidoComun> pedidos)
        {
            return pedidos.Select(pedido => ToPedidoComun(pedido)).ToList();
        }

        public static List<DTOPedidoComun> ToListadoPedidoComunDTO(List<PedidoComun> pedidos)
        {
            return pedidos.Select(pedido => ToDTOPedidoComun(pedido)).ToList();
        }




        //Express
        public static PedidoExpress ToPedidoExpress(DTOPedidoExpress pedido)
        {
            PedidoExpress nuevo = new PedidoExpress()
            {
                cliente = MapperCliente.ToCliente(pedido.cliente),
                lineas = MapperLinea.ToListadoLinea(pedido.lineas),
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,
                plazoDias = pedido.plazoDias,
                activo = pedido.activo
            };
            return nuevo;
        }

        public static DTOPedidoExpress ToDTOPedidoExpress(PedidoExpress pedido)
        {

            if (pedido != null)
            {
                return new DTOPedidoExpress()
                {
                    id = pedido.id,
                    cliente = MapperCliente.ToDTOCliente(pedido.cliente),
                    lineas = MapperLinea.ToListadoLineaDTO(pedido.lineas),
                    total = pedido.total,
                    IVA = pedido.IVA,
                    recarga = pedido.recarga,
                    fechaPrometida = pedido.fechaPrometida,
                    plazoDias = pedido.plazoDias,
                    activo = pedido.activo
                };
            }
            return null;
        }

        public static List<PedidoExpress> ToListadoPedidoExpress(List<DTOPedidoExpress> pedidos)
        {
            return pedidos.Select(pedido => ToPedidoExpress(pedido)).ToList();
        }
        public static List<DTOPedidoExpress> ToListadoPedidoExpressDTO(List<PedidoExpress> pedidos)
        {
            return pedidos.Select(pedido => ToDTOPedidoExpress(pedido)).ToList();
        }



        public static Pedido ToPedido(DTOPedido pedido)
        {
            Pedido nuevo = new Pedido()
            {
                cliente = MapperCliente.ToCliente(pedido.cliente),
                lineas = MapperLinea.ToListadoLinea(pedido.lineas),
                total = pedido.total,
                IVA = pedido.IVA,
                fechaPrometida = pedido.fechaPrometida,
                activo = pedido.activo
            };
            return nuevo;
        }


        public static DTOPedido ToDTOPedido(Pedido pedido)
        {

            if (pedido != null)
            {
                return new DTOPedido()
                {
                    id = pedido.id,
                    cliente = MapperCliente.ToDTOCliente(pedido.cliente),
                    lineas = MapperLinea.ToListadoLineaDTO(pedido.lineas),
                    total = pedido.total,
                    IVA = pedido.IVA,
                    fechaPrometida = pedido.fechaPrometida,
                    activo = pedido.activo
                };
            }
            return null;
        }

        public static List<Pedido> ToListadoPedido(List<DTOPedido> pedidos)
        {
            return pedidos.Select(pedido => ToPedido(pedido)).ToList();
        }
        public static List<DTOPedido> ToListadoPedidoDTO(List<Pedido> pedidos)
        {
            return pedidos.Select(pedido => ToDTOPedido(pedido)).ToList();
        }



        public static DTOPedidoSimple ToDTOPedidoSimpe (Pedido pedido)
        {

            if (pedido != null)
            {
                return new DTOPedidoSimple()
                {
                    id = pedido.id,
                    cliente = MapperCliente.ToDTOCliente(pedido.cliente),
                    total = pedido.total,
                    IVA = pedido.IVA,
                    fechaPrometida = pedido.fechaPrometida,
                };
            }
            return null;
        }
        public static List<DTOPedidoSimple> ToListadoPedidoSimpleDTO(List<Pedido> pedidos)
        {
            return pedidos.Select(pedido => ToDTOPedidoSimpe(pedido)).ToList();
        }
    }
}
