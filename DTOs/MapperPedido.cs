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
        public static Pedido ToPedido(DTOPedido pedido)
        {
            return new Pedido()
            {
                id = pedido.id,
                cliente = pedido.cliente,
                lineas = pedido.lineas,
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,               
            };
        }

        public static DTOPedido ToDTOPedido(Pedido pedido)
        {

            return new DTOPedido()
            {
                id = pedido.id,
                cliente = pedido.cliente,
                lineas = pedido.lineas,
                total = pedido.total,
                IVA = pedido.IVA,
                recarga = pedido.recarga,
                fechaPrometida = pedido.fechaPrometida,
            };
        }
        public static List<DTOPedido> ToListadoPedidoDTO(List<Pedido> pedidos)
        {
            return pedidos.Select(pedidos => ToDTOPedido(pedidos)).ToList();
        }

    }
}
