using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Finanzas : Concesionario
    {
        public Finanzas() { }
        public float Total_Ingresos { get; set; }
        public float Total_Gastos { get; set; }
        public float Rentabilidad { get; set; }

        public Finanzas(float total_Ingresos,float dinero_total, float total_Gastos)
        {
            Total_Ingresos = total_Ingresos;
            Dinero_Total = dinero_total;
            Total_Gastos = total_Gastos;
        }
    }
}
