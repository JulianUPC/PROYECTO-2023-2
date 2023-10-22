using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioEmpleados : Conexion
    {
        public RepositorioEmpleados(string connectionString) : base(connectionString)
        {
        }
        public void Insert(Cliente cliente)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Clientes (N_Identificacion,Nombre_Completo,Fecha_Nacimiento,Genero,Direccion,Telefono,Trabaja,Cargo,Ingresos_Mensuales,Presupuesto,Fecha_Registro,Licencia,Usuario,Contraseña,Autos_Comprados,Correo_Electronico) values (@N_Identificacion,@Nombre_Completo,@Fecha_Nacimiento,@Genero,@Direccion,@Telefono,@Trabaja,@Cargo,@Ingresos_Mensuales,@Presupuesto,@Fecha_Registro,@Licencia,@Usuario,@Contraseña,@Autos_Comprados,@Correo_Electronico)";
                Comando.Parameters.Add("@N_Identificacion", SqlDbType.Int).Value = cliente.N_Identificacion;
                Comando.Parameters.Add("@Nombre_Completo", SqlDbType.VarChar).Value = cliente.Nombre_Completo;
                Comando.Parameters.Add("@Fecha_Nacimiento", SqlDbType.DateTime).Value = cliente.Fecha_Nacimiento;
                Comando.Parameters.Add("@Genero", SqlDbType.VarChar).Value = cliente.Genero;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = cliente.Telefono;
                Comando.Parameters.Add("@Trabaja", SqlDbType.VarChar).Value = cliente.Trabaja;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = cliente.Cargo;
                Comando.Parameters.Add("@Presupuesto", SqlDbType.Int).Value = cliente.Presupuesto;
                Comando.Parameters.Add("@Ingresos_Mensuales", SqlDbType.Int).Value = cliente.Ingresos_Mensuales;
                Comando.Parameters.Add("@Fecha_Registro", SqlDbType.DateTime).Value = cliente.Fecha_Registro;
                Comando.Parameters.Add("@Licencia", SqlDbType.VarChar).Value = cliente.Licencia;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = cliente.Usuario;
                Comando.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = cliente.Contraseña;
                Comando.Parameters.Add("@Autos_Comprados", SqlDbType.Int).Value = cliente.Autos_Comprados;
                Comando.Parameters.Add("@Correo_Electronico", SqlDbType.VarChar).Value = cliente.Correo_Electronico;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        public void Update(Cliente PersonaLog)
        {
        }

        public void Delete(Cliente PersonaLog)
        {
        }

        private Cliente Mapeador_cliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cliente clienteLog = new Cliente();
            clienteLog.N_Identificacion = dataReader.GetInt32(0);
            clienteLog.Nombre_Completo = dataReader.GetString(1);
            clienteLog.Fecha_Nacimiento = dataReader.GetDateTime(2);
            clienteLog.Genero = dataReader.GetString(3);
            clienteLog.Direccion = dataReader.GetString(4);
            clienteLog.Telefono = dataReader.GetString(5);
            clienteLog.Trabaja = dataReader.GetString(6);
            clienteLog.Cargo = dataReader.GetString(7);
            clienteLog.Presupuesto = dataReader.GetInt32(8);
            clienteLog.Ingresos_Mensuales = dataReader.GetInt32(9);
            clienteLog.Fecha_Registro = dataReader.GetDateTime(10);
            clienteLog.Licencia = dataReader.GetString(11);
            clienteLog.Usuario = dataReader.GetString(12);
            clienteLog.Contraseña = dataReader.GetString(13);
            clienteLog.Autos_Comprados = dataReader.GetInt32(14);
            clienteLog.Correo_Electronico = dataReader.GetString(15);

            return clienteLog;
        }
        public List<Cliente> GetAll()
        {
            List<Cliente> cliente = new List<Cliente>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM Clientes";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                cliente.Add(Mapeador_cliente(lector));
            }
            Close();
            return cliente;
        }
    }
}
