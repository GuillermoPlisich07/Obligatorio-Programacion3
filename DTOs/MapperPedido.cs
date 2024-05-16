using LogicaNegocio.Dominio;
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
            return new PedidoComun()
            {
                id = pedido.id,
                cliente = MapperCliente.ToCliente(pedido.cliente),
                lineas = MapperLinea.ToListadoLinea(pedido.lineas),
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,
                distancia = pedido.distancia,
                activo = pedido.activo
            };
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
            return new PedidoExpress()
            {
                id = pedido.id,
                cliente = MapperCliente.ToCliente(pedido.cliente),
                lineas = MapperLinea.ToListadoLinea(pedido.lineas),
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,
                plazoDias = pedido.plazoDias,
                activo = pedido.activo
            };
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
    }
}
