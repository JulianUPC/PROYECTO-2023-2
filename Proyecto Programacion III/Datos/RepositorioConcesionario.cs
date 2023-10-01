using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioConcesionario
    {
        string lugar = "Concesionario.txt";
        public void GuardarEstablecimiento(Concesionario cliente)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(cliente.ToString());
            writer.Close();
        }

        public Concesionario Mapper(string linea)
        {
            var concesionario = new Concesionario();
            string[] datos = linea.Split(';');
            concesionario.Id_Cliente = int.Parse(datos[0]);
            concesionario.Id_Auto = int.Parse(datos[1]);
            concesionario.Diner_Total = float.Parse(datos[2]);
            concesionario.Clientes_Registrados = int.Parse(datos[3]);
            return concesionario;
        }

        public List<Concesionario> GetAll()
        {
            try
            {
                List<Concesionario> concesionarios = new List<Concesionario>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    concesionarios.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return concesionarios;
            }
            catch (Exception)
            {

                return null;
            }
        }
        /*public void EliminaConcesionario(List<Concesionario> concesionarios)
        {
            string lugartemp = "Temporal.txt";
            try
            {
                StreamWriter sw = new StreamWriter(lugartemp, true);
                foreach (var item in concesionarios)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.Close();
                File.Delete(lugar);
                File.Move(lugartemp, lugar);
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
