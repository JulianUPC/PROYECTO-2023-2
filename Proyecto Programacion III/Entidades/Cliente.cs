using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public Cliente() { }
        public string N_Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Autos_Comprados { get; set; }
        public string Correo_Electronico { get; set; }

        public Cliente(string n_Identificacion, string nombres, string apellidos, char sexo, string telefono, string direccion, DateTime fecha_Registro, int autos_Comprados, string correo_Electronico)
        {
            N_Identificacion = n_Identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Sexo = sexo;
            Telefono = telefono;
            Direccion = direccion;
            Fecha_Registro = fecha_Registro;
            Autos_Comprados = autos_Comprados;
            Correo_Electronico = correo_Electronico;
        }
    }
}
