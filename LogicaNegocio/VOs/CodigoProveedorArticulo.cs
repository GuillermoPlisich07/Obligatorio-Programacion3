using LogicaNegocio.ExcepcionesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs
{
    [Owned]
    public class CodigoProveedorArticulo
    {
        public int Valor { get; init; }


        public CodigoProveedorArticulo(int codigo)
        {
            Valor = codigo;
            Validar();
        }

        private CodigoProveedorArticulo() { }

        public void Validar()
        {
            if (Valor == null || Valor == 0)
            {
                throw new DatosInvalidosException("El valor es obligatorio y no puede ser nulo o cero.");
            }

            if (Valor == 13)
            {
                throw new DatosInvalidosException("El codigo de proveedor debe ser de 13 digitos.");
            }
        }

        public override bool Equals(object? obj)
        {
            CodigoProveedorArticulo otro = obj as CodigoProveedorArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
