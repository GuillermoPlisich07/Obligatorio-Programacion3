using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using LogicaNegocio.VOs;

namespace LogicaNegocio.Dominio
{
    public class Articulo : IValidable
    {
        
        public int id { get; set; }

        public NombreArticulo nombre { get; set; }

        public DescripcionArticulo descripcion { get; set; }

        public CodigoProveedorArticulo codigoProveedor { get; set; }

        public decimal precioPublico { get; set; }

        public int stock { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
