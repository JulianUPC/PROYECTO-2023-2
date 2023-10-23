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
        public int Dinero_Total { get; set; }
        public Concesionario(int id_Cliente, int id_Auto, int dinero_Total)
        {
            Id_Cliente = id_Cliente;
            Id_Auto = id_Auto;
            Dinero_Total = dinero_Total;
        }
        public void Calcular_DineroTotal(int ingresos, int gastos)
        {
            Dinero_Total = ingresos - gastos;
        }
    }
}
