using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        public Auto() { }
        public int Id_Auto { get; set; }
        public float Precio { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Categoria { get; set; }
        public DateTime Año { get; set; }

        public Auto(int id_Auto, float precio, string matricula, string marca, string modelo, string color, string categoria, DateTime año)
        {
            Id_Auto = id_Auto;
            Precio = precio;
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Categoria = categoria;
            Año = año;
        }
    }
}
