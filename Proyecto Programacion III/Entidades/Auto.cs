using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Cliente
    {
        public Auto() { }
        public string Nombre_Auto { get; set; }
        public int Precio { get; set; }      
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public string Motor {  get; set; }
        public string Potencia { get; set; }
        public string Valvulas { get; set; }    
        public string Asientos { get; set; }
        public string Sistema_Combustible { get; set; }
        public string Tipo_Transmision {  get; set; }

        public Auto(string nombre_Auto, int precio, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision)
        {        
            Nombre_Auto = nombre_Auto;
            Precio = precio;          
            Modelo = modelo;
            Categoria = categoria;
            Motor = motor;
            Potencia = potencia;
            Valvulas = valvulas;
            Asientos = asientos;
            Sistema_Combustible = sistema_Combustible;
            Tipo_Transmision = tipo_Transmision;
        }
    }
}
