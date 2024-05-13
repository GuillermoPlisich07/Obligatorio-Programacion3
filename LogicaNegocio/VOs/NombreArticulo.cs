using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.VOs
{
    [Owned]
    public class NombreArticulo
    {
        public string Valor { get; init; } // Inmutable
        public NombreArticulo(string nombre)
        {
            Valor = nombre;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new DatosInvalidosException("El nombre es obligatorio no puede ser nulo.");
            }

            if (Valor.Length >= 10 && Valor.Length <= 200)
            {
                throw new DatosInvalidosException("El nombre del articulo tiene que tener un minimo de 10.");
            }
        }

        public override bool Equals(object? obj)
        {
            NombreArticulo otro = obj as NombreArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }

    }
}
