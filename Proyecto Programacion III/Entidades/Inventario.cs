using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventario
    {
        public Inventario() { }
        public bool Disponibilidad { get; set; }
        public int Total_Autos { get; set; }

        public Inventario(bool disponibilidad, int total_Autos)
        {
            Disponibilidad = disponibilidad;
            Total_Autos = total_Autos;
        }
    }
}
