using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class Servicio_Ventas
    {
        Ventas ventas = new Ventas();
        Datos.Repositorio_Ventas repositorio_Ventas;
        public Servicio_Ventas(string conexion)
        {
            repositorio_Ventas = new Repositorio_Ventas(conexion);
        }
        public List<Ventas> GetAll()
        {
            return repositorio_Ventas.GetAll();
        }
    }
}
