using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Concesionario
    {
        public Cliente() { }
        public int N_Identificacion { get; set; }
        public string Nombre_Completo { get; set; }
        public DateTime Fecha_Nacimiento{ get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Trabaja { get; set; }
        public string Cargo { get; set; }
        public int Presupuesto { get; set; }
        public int Ingresos_Mensuales { get; set; }       
        public DateTime Fecha_Registro { get; set; }
        public string Licencia { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int Autos_Comprados { get; set; }
        public string Correo_Electronico { get; set; }

        public Cliente(int n_Identificacion,string nombre_completo,DateTime fecha_Nacimiento,string genero,string direccion,string telefono,string trabaja,string cargo, int presupuesto, int ingresos_Mensuales,DateTime fecha_Registro,string licencia,string usuario,string contraseña,int autos_Comprados,string correo_Electronico)
        {
            N_Identificacion = n_Identificacion;
            Nombre_Completo = nombre_completo;
            Fecha_Nacimiento = fecha_Nacimiento;
            Genero = genero;
            Direccion = direccion;
            Telefono = telefono;
            Trabaja = trabaja;
            Cargo = cargo;
            Presupuesto = presupuesto;
            Ingresos_Mensuales = ingresos_Mensuales;       
            Fecha_Registro = fecha_Registro;
            Licencia = licencia;
            Usuario = usuario;
            Contraseña = contraseña;
            Autos_Comprados = autos_Comprados;
            Correo_Electronico = correo_Electronico;
        }
    }
}
