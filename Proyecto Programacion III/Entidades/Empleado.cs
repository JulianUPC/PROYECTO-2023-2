using System;
using System.Collections.Generic;
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
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public float Comision_Aplicada { get; set; }

        public Empleado(int id_cliente, string iD_Empleado, string n_identificacion, string nombres, string apellidos, DateTime fecha_Ingreso, float comision_Aplicada)
        {
            Id_Cliente = id_cliente;
            ID_Empleado = iD_Empleado;
            N_identificacion = n_identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Fecha_Ingreso = fecha_Ingreso;
            Comision_Aplicada = comision_Aplicada;
        }
    }
}
