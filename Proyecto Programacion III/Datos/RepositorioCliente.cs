using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioCliente
    {
        string lugar = "Clientes.txt";
        public void GuardarCliente(Cliente cliente)
        {
            StreamWriter writer = new StreamWriter(lugar, true);
            writer.WriteLine(cliente.ToString());
            writer.Close();
        }

        public Cliente Mapper(string linea)
        {
            var cliente = new Cliente();
            string[] datos = linea.Split(';');
            cliente.N_Identificacion = datos[0];
            cliente.Nombres = datos[1];
            cliente.Apellidos = datos[2];
            cliente.Sexo = char.Parse(datos[3]);
            cliente.Telefono = datos[4];
            cliente.Direccion = datos[5];
            cliente.Fecha_Registro = DateTime.Parse(datos[6]);
            cliente.Autos_Comprados = int.Parse(datos[7]);
            cliente.Correo_Electronico = datos[7];
            return cliente;
        }

        public List<Cliente> GetAll()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                StreamReader reader = new StreamReader(lugar);
                while (!reader.EndOfStream)
                {
                    clientes.Add(Mapper(reader.ReadLine()));
                }
                reader.Close();
                return clientes;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
