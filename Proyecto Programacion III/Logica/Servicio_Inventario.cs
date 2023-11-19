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
    public class Servicio_Inventario 
    {
        Datos.RepositorioInventario repositorioInventario;
        public Servicio_Inventario(string conexion)
        {
            repositorioInventario = new RepositorioInventario(conexion);
        }
        public void Insertar(Inventario inventario)
        {
            repositorioInventario.Insert(inventario);
        }

        public void Delete(Inventario inventario)
        {
            repositorioInventario.Delete(inventario);
        }
        public int ContarInventario()
        {
            int total_inventario = 0;
            foreach (var item in GetAll())
            {
                total_inventario++;
            }
            return total_inventario;
        }

        public List<Inventario> Buscar_Auto(string matricula)
        {
            try
            {
                List<Inventario> ListaPorIA = new List<Inventario>();
                if (GetAll() == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in GetAll())
                    {
                        if (item.Matricula.Equals(matricula))
                        {
                            ListaPorIA.Add(item);
                        }
                    }
                }
                return ListaPorIA;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Inventario> GetAll()
        {
            return repositorioInventario.GetAll();
        }
        public DataTable GetAllTabla()
        {
            return repositorioInventario.GetAllTabla();
        }
    }
}
