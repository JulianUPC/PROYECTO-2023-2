using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioPagos
    {
        string lugar = "Pagos.txt";
        public void GuardarPagos(Pagos pagos)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(pagos.ToString());
            writer.Close();
        }

        public Pagos Mapper(string linea)
        {
            var pagos = new Pagos();
            string[] datos = linea.Split(';');

            return pagos;
        }

        public List<Pagos> GetAll()
        {
            try
            {
                List<Pagos> pagos = new List<Pagos>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    pagos.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return pagos;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
