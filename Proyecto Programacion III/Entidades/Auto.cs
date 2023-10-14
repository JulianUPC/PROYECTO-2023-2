using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Concesionario
    {
        public Auto() { }
        public string Matricula { get; set; }
        public string Nombre_Auto { get; set; }
        public float Precio { get; set; }      
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public string Motor {  get; set; }
        public string Potencia { get; set; }
        public string Valvulas { get; set; }    
        public string Asientos { get; set; }
        public string Sistema_Combustible { get; set; }
        public string Tipo_Transmision {  get; set; }
        public DateTime Año { get; set; }

        public Auto(int id_auto,string matricula, string nombre_Auto, float precio, string marca, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision, DateTime año)
        {
            Id_Auto = id_auto;
            Matricula = matricula;
            Nombre_Auto = nombre_Auto;
            Precio = precio;          
            Marca = marca;
            Modelo = modelo;
            Categoria = categoria;
            Motor = motor;
            Potencia = potencia;
            Valvulas = valvulas;
            Asientos = asientos;
            Sistema_Combustible = sistema_Combustible;
            Tipo_Transmision = tipo_Transmision;
            Año = año;
        }
    }
}
