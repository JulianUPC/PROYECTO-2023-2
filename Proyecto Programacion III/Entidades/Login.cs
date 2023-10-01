using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        public Login() { }
        public string N_Identificacion { get; set; }
        public string Nombre_Completo { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool Trabjo { get; set; }
        public string Cargo { get; set; }
        public float Ingreso_Mensual { get; set; } 
        public float Presupuesto { get; set; }
        public bool Licencia { get; set; }

        public Login(string n_Identificacion, string nombre_Completo, char sexo, string telefono, string direccion, DateTime fecha_Nacimiento, bool trabjo, string cargo, float ingreso_Mensual, float presupuesto, bool licencia)
        {
            N_Identificacion = n_Identificacion;
            Nombre_Completo = nombre_Completo;
            Sexo = sexo;
            Telefono = telefono;
            Direccion = direccion;
            Fecha_Nacimiento = fecha_Nacimiento;
            Trabjo = trabjo;
            Cargo = cargo;
            Ingreso_Mensual = ingreso_Mensual;
            Presupuesto = presupuesto;
            Licencia = licencia;
        }
    }
}
