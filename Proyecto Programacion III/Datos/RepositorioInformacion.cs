using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioInformacion
    {
        string lugar = "Informacion.txt";
        public void GuardarInformacion(Informacion informacion)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(informacion.ToString());
            writer.Close();
        }

        public Informacion Mapper(string linea)
        {
            var informacion = new Informacion();
            string[] datos = linea.Split(';');
            
            return informacion;
        }

        public List<Informacion> GetAll()
        {
            try
            {
                List<Informacion> informacion = new List<Informacion>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    informacion.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return informacion;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
