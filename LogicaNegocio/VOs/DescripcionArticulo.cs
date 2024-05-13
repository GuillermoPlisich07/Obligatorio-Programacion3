using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.VOs
{
    [Owned]
    public class DescripcionArticulo
    {
        public string Valor { get; set; }

        public DescripcionArticulo(string descripcion)
        {
            Valor = descripcion;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                throw new DatosInvalidosException("La descripcion es obligatorio no puede ser nula.");
            }

            if (Valor.Length >= 5)
            {
                throw new DatosInvalidosException("La descricpion del articulo no es valida");
            }
        }

        public override bool Equals(object? obj)
        {
            DescripcionArticulo otro = obj as DescripcionArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
