﻿using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class Servicio_Inventario : ICrud<Inventario>
    {
        Datos.RepositorioInventario RepositorioInventario;
        public Servicio_Inventario(string conexion)
        {
            RepositorioInventario = new RepositorioInventario(conexion);
        }
        public void Insertar(Inventario inventario)
        {
            RepositorioInventario.Insert(inventario);
        }

        public void Delete(Inventario inventario)
        {
            RepositorioInventario.Delete(inventario);
        }

        public void Update(string id, Inventario inventario)
        {
            RepositorioInventario.Update(id, inventario);
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
        public List<Inventario> Buscar_Auto(string id_auto)
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
                        if (item.Id_Auto.Equals(id_auto))
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
            return RepositorioInventario.GetAll();
        }
    }
}