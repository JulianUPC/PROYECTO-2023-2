using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioInventario
    {
        string lugar = "Inventario.txt";
        public void GuardarInventario(Inventario inventario)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(inventario.ToString());
            writer.Close();
        }

        public Inventario Mapper(string linea)
        {
            var inventario = new Inventario();
            string[] datos = linea.Split(';');
            inventario.Disponibilidad = bool.Parse(datos[0]);
            inventario.Total_Autos = int.Parse(datos[1]);
            return inventario;
        }

        public List<Inventario> GetAll()
        {
            try
            {
                List<Inventario> inventarios = new List<Inventario>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    inventarios.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return inventarios;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

