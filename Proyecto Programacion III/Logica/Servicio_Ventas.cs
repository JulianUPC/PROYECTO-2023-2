using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
        public void Insertar(Ventas ventas)
        {
            repositorio_Ventas.Insert(ventas);
        }
        public List<Ventas> GetAll()
        {
            return repositorio_Ventas.GetAll();
        }
        public DataTable GetAllAuto_Clientes(string comprador)
        {
            return repositorio_Ventas.GetAllTabla_Auto_Cliente(comprador);
        }
        public DataTable GetAllTabla()
        {
            return repositorio_Ventas.GetAllTabla();
        }

    }
}
