using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Finanzas
    {
        public Finanzas() { }
        public float Total_Ingresos { get; set; }
        public float Total_Gastos { get; set; }

        public Finanzas(float total_Ingresos, float total_Gastos)
        {
            Total_Ingresos = total_Ingresos;
            Total_Gastos = total_Gastos;
        }
    }
}
