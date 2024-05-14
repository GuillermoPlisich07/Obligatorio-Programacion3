using LogicaNegocio.Dominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperArticulo
    {
        public static Articulo ToArticulo(DTOArticulo articulo)
        {
            return new Articulo()
            {
                id = articulo.Id,
                nombre = new NombreArticulo(articulo.Nombre),
                descripcion = new DescripcionArticulo(articulo.Descripcion),
                codigoProveedor = new CodigoProveedorArticulo(articulo.CodigoProveedor),
                precioPublico = articulo.PrecioPublico,
                stock = articulo.Stock
            };
        }

        public static DTOArticulo ToDTOArticulo(Articulo articulo)
        {

            return new DTOArticulo()
            {
                Id = articulo.id,
                Nombre = articulo.nombre.Valor,
                Descripcion = articulo.descripcion.Valor,
                CodigoProveedor = articulo.codigoProveedor.Valor,
                PrecioPublico = articulo.precioPublico,
                Stock = articulo.stock
            };
        }
        public static List<DTOArticulo> ToListadoSimpleDTO(List<Articulo> articulos)
        {
            return articulos.Select(articulos => ToDTOArticulo(articulos)).ToList();
        }

        public static List<DTOArticulo> ToListadoOrdenado(List<Articulo> articulos)
        {
            return articulos.OrderBy(articulo => articulo.nombre).Select(articulo => ToDTOArticulo(articulo)).ToList();
        }
    }

}

