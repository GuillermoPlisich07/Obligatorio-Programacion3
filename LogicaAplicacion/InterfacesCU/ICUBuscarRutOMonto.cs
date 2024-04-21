using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUBuscarRutOMonto<T>
    {
       List<T> Buscar(string rut, string razonSocial, decimal monto);
    }
}
