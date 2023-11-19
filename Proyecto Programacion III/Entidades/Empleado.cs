using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Concesionario
    {
        public Empleado() { }
        public string ID_Empleado { get; set; }
        public string N_identificacion { get; set; }
        public string Nombre_Completo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Pago_Mes { get; set; }
        public int Monto_Comision { get; set; }
        public string Cargo { get; set; }

        public Empleado(string iD_Empleado, string n_identificacion, string nombre_completo, DateTime fecha_Ingreso, int pago_Mes,int monto_comision,string cargo)
        {
            ID_Empleado = iD_Empleado;
            N_identificacion = n_identificacion;
            Nombre_Completo = nombre_completo;
            Fecha_Ingreso = fecha_Ingreso;
            Pago_Mes = pago_Mes;
            Monto_Comision = monto_comision;
            Cargo = cargo;
        }
        public int Calcular_Comision(int Precio_Auto)
        {
            decimal Comision = 0.06m;
            int Pago_Total = 0;
            Pago_Total = Convert.ToInt32(Precio_Auto * Comision);
            return Pago_Total;
        }
    }
}
