using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperLinea
    {
        public static Linea ToLinea(DTOLinea linea)
        {
            return new Linea()
            {
                id = linea.id,
                articulo = MapperArticulo.ToArticulo(linea.articulo),
                cantUnidades = linea.cantUnidades,
                preUnitarioVigente = linea.preUnitarioVigente

            };
        }

        public static DTOLinea ToDTOLinea(Linea linea)
        {

            return new DTOLinea()
            {
                id = linea.id,
                articulo = MapperArticulo.ToDTOArticulo(linea.articulo),
                cantUnidades = linea.cantUnidades,
                preUnitarioVigente = linea.preUnitarioVigente
            };
        }

        public static List<DTOLinea> ToListadoLineaDTO(List<Linea> lineas)
        {
            return lineas.Select(linea => ToDTOLinea(linea)).ToList();
        }

        public static List<Linea> ToListadoLinea(List<DTOLinea> lineas)
        {
            return lineas.Select(linea => ToLinea(linea)).ToList();
        }
    }
}
