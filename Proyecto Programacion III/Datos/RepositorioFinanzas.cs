using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioFinanzas
    {
        string lugar = "Finanzas.txt";
        public void GuardarFinanzas(Finanzas finanzas)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(finanzas.ToString());
            writer.Close();
        }

        public Finanzas Mapper(string linea)
        {
            var finanzas = new Finanzas();
            string[] datos = linea.Split(';');
            finanzas.Total_Ingresos = float.Parse(datos[0]);
            finanzas.Total_Gastos = float.Parse(datos[1]);
            return finanzas;
        }

        public List<Finanzas> GetAll()
        {
            try
            {
                List<Finanzas> finanzas = new List<Finanzas>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    finanzas.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return finanzas;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
