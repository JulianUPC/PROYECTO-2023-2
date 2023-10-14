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
        public string N_Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento{ get; set; }
        public char Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Trabaja { get; set; }
        public string Cargo { get; set; }
        public float Ingresos_Mensuales { get; set; }
        public float Presupuesto { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Licencia { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int Autos_Comprados { get; set; }
        public string Correo_Electronico { get; set; }

        public Cliente(int id_auto,string n_Identificacion, string nombres, string apellidos, DateTime fecha_Nacimiento, char genero, string direccion, string telefono, string trabaja, string cargo, float ingresos_Mensuales, float presupuesto, DateTime fecha_Registro, string licencia, string usuario, string contraseña, int autos_Comprados, string correo_Electronico)
        {
            Id_Auto = id_auto;
            N_Identificacion = n_Identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Fecha_Nacimiento = fecha_Nacimiento;
            Genero = genero;
            Direccion = direccion;
            Telefono = telefono;
            Trabaja = trabaja;
            Cargo = cargo;
            Ingresos_Mensuales = ingresos_Mensuales;
            Presupuesto = presupuesto;
            Fecha_Registro = fecha_Registro;
            Licencia = licencia;
            Usuario = usuario;
            Contraseña = contraseña;
            Autos_Comprados = autos_Comprados;
            Correo_Electronico = correo_Electronico;
        }
    }
}
