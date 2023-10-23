using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas : Auto
    {
        public Ventas() { }
        public DateTime Fecha_Vendido { get; set; }
        public string ID_Comprador { get; set; }
        public string Matricula { get; set; }
        public Ventas(DateTime fecha_Vendido,string Id_Comprador,int id_auto,string matricula, string nombre_Auto, int precio, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision)
        {
            Fecha_Vendido = fecha_Vendido;
            ID_Comprador = Id_Comprador;
            Id_Auto = id_auto;
            Matricula = matricula;
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
