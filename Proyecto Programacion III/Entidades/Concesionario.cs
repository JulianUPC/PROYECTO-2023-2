using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionario
    {
        public Concesionario() { }
        public string Id_Cliente { get; set; }
        public string Id_Auto { get; set; }
        public Concesionario(string id_Cliente, string id_Auto)
        {
            Id_Cliente = id_Cliente;
            Id_Auto = id_Auto;
        }
    }
}
