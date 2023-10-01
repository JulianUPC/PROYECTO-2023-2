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
        public int Id_Cliente { get; set; }
        public int Id_Auto { get; set; }
        public float Diner_Total { get; set; }
        public int Clientes_Registrados { get; set; }

        public Concesionario(int id_Cliente, int id_Auto, float diner_Total, int clientes_Registrados)
        {
            Id_Cliente = id_Cliente;
            Id_Auto = id_Auto;
            Diner_Total = diner_Total;
            Clientes_Registrados = clientes_Registrados;
        }
    }
}
