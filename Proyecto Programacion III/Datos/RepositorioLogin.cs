using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioLogin
    {
        string lugar = "Login.txt";
        public void GuardarLogin(Login login)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(login.ToString());
            writer.Close();
        }

        public Login Mapper(string linea)
        {
            var login = new Login();
            string[] datos = linea.Split(';');
            login.N_Identificacion = datos[0];
            login.Nombre_Completo = datos[1];
            login.Sexo = char.Parse(datos[2]);
            login.Telefono = datos[3];
            login.Direccion = datos[4];
            login.Fecha_Nacimiento = DateTime.Parse(datos[5]);
            login.Trabjo = bool.Parse(datos[6]);
            login.Cargo = datos[7];
            login.Ingreso_Mensual = float.Parse(datos[8]);
            login.Presupuesto = float.Parse(datos[8]);
            login.Licencia = bool.Parse(datos[9]);
            return login;
        }

        public List<Login> GetAll()
        {
            try
            {
                List<Login> logins = new List<Login>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    logins.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return logins;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
