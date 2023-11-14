using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventario : Auto
    {
        public Inventario() { }
        public DateTime Fecha_Compra { get; set; }
        public string Matricula { get; set; }
        public Inventario(DateTime fecha_compra,string matricula, string nombre_Auto, int precio_venta, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision, string id_auto)
        {
            Fecha_Compra = fecha_compra;
            Matricula = matricula;          
            Nombre_Auto = nombre_Auto;
            Precio_Venta = precio_venta;
            Modelo = modelo;
            Categoria = categoria;
            Motor = motor;
            Potencia = potencia;
            Valvulas = valvulas;
            Asientos = asientos;
            Sistema_Combustible = sistema_Combustible;
            Tipo_Transmision = tipo_Transmision;
            Id_Auto = id_auto;
        }
    }
}
