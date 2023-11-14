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
        public string Matricula { get; set; }
        public Ventas(DateTime fecha_Vendido,string Id_Comprador,string id_cliente,string id_auto,string matricula, string nombre_Auto, int precio_venta, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision)
        {
            Fecha_Vendido = fecha_Vendido;
            Id_Cliente = id_cliente;
            Id_Auto = id_auto;
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
        }
    }
}
