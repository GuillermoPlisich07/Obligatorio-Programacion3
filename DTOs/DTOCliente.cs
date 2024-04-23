using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOCliente
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public int RUT { get; set; }
    }
}
