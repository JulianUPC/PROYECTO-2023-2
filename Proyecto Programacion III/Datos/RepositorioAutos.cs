using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioAutos
    {
        string lugar = "Autos.txt";
        public void GuardarAuto(Auto auto)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(auto.ToString());
            writer.Close();
        }

        public Auto Mapper(string linea)
        {
            var auto = new Auto();
            string[] datos = linea.Split(';');
            auto.Id_Auto = int.Parse(datos[0]);
            auto.Precio = float.Parse(datos[1]);
            auto.Matricula = datos[2];
            auto.Marca = datos[3]; 
            auto.Modelo = datos[4];
            auto.Color = datos[5];
            auto.Categoria = datos[6];
            auto.Año = DateTime.Parse(datos[7]);
            return auto;
        }

        public List<Auto> GetAll()
        {
            try
            {
                List<Auto> autos = new List<Auto>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    autos.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return autos;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
