using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Cliente")]
    public class Cliente
    {
        public int id { get; set; }
        public string razonSocial {  get; set; }
        public int RUT { get; set; }
        public string ciudad { get; set; }
        public int numPuerta { get; set; }
        public string calle { get; set; }
        public decimal distancia { get; set;}
    }
}
