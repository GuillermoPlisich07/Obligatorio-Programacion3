using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Usuario : IValidable
    {
        public int id { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
