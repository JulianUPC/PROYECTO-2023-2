using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autos_de_Clientes : Auto
    {
        public Autos_de_Clientes() { }
        public int Precio_de_Compra { get; set; }
        public Autos_de_Clientes(string id_cliente,string id_auto,string nombre_Auto, int precio_venta, string modelo, string categoria, string motor, string potencia, string valvulas, string asientos, string sistema_Combustible, string tipo_Transmision,int precio_de_compra)
        {
            Id_Cliente = id_cliente;
            Id_Auto = id_auto;
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
            Precio_de_Compra = precio_de_compra;       
        }
    }
}
