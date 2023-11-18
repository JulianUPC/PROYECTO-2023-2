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
        public string Comprador { get; set; }
        public string Nombre_Vendedor { get; set; }
        public DateTime Fecha_Vendido { get; set; }
        public string Matricula { get; set; }
        public Ventas(string id_cliente,string comprador,string nombre_vendedor, DateTime fecha_Vendido,int precio_venta,string id_auto,string matricula, string nombre_Auto, string categoria, string motor, string potencia, string sistema_Combustible, string tipo_Transmision)
        {
            Id_Cliente = id_cliente;
            Comprador = comprador;
            Nombre_Vendedor = nombre_vendedor;
            Fecha_Vendido = fecha_Vendido;
            Precio_Venta = precio_venta;
            Id_Auto = id_auto;
            Matricula = matricula;
            Nombre_Auto = nombre_Auto;
            Categoria = categoria;
            Motor = motor;
            Potencia = potencia;
            Sistema_Combustible = sistema_Combustible;
            Tipo_Transmision = tipo_Transmision;

        }
    }
}
