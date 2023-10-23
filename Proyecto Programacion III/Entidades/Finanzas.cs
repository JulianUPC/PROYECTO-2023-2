using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Finanzas 
    {
        public Finanzas() { }
      
        public string Tipo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Monto_Ingreso { get; set; }
        public DateTime Fecha_Gasto { get; set; }
        public int Monto_Gasto { get; set; }
        public string Nombre_Auto { get; set; }

        public Finanzas(string tipo,DateTime fecha_ingreso,int monto_ingreso ,DateTime fecha_gasto,int monto_gasto,string nombre_auto)
        {
            Tipo = tipo;
            Fecha_Ingreso = fecha_ingreso;
            Monto_Ingreso = monto_ingreso;           
            Fecha_Gasto = fecha_gasto;   
            Monto_Gasto = monto_gasto;
            Nombre_Auto = nombre_auto;
        }
    }
}
