using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperImpuesto
    {
        public static Impuesto ToImpuesto(DTOImpuesto impuesto)
        {

            return new Impuesto()
            {
                id = impuesto.id,
                IVA = impuesto.IVA,
                entregaExpressComun = impuesto.entregaExpressComun,
                entregaExpressMismoDia = impuesto.entregaExpressMismoDia,
                entregaComunMayorCien = impuesto.entregaComunMayorCien,

            };
        }

        public static DTOImpuesto ToDTOImpuesto(Impuesto impuesto)
        {

            return new DTOImpuesto()
            {
                id = impuesto.id,
                IVA = impuesto.IVA,
                entregaExpressComun = impuesto.entregaExpressComun,
                entregaExpressMismoDia = impuesto.entregaExpressMismoDia,
                entregaComunMayorCien = impuesto.entregaComunMayorCien,
            };
        }

    }
}
