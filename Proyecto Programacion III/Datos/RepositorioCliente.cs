using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.OracleClient;

namespace Datos
{
    public class RepositorioCliente : Conexion
    {
        public RepositorioCliente(string connectionString) : base(connectionString)
        {
        }

        public void Insert(Cliente cliente)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Clientes (Id_Cliente,N_Identificacion,Nombre_Completo,Fecha_Nacimiento,Genero,Direccion,Telefono,Trabaja,Cargo,Ingresos_Mensuales,Presupuesto,Fecha_Registro,Licencia,Usuario,Contraseña,Autos_Comprados,Correo_Electronico) values (@Id_Cliente,@N_Identificacion,@Nombre_Completo,@Fecha_Nacimiento,@Genero,@Direccion,@Telefono,@Trabaja,@Cargo,@Ingresos_Mensuales,@Presupuesto,@Fecha_Registro,@Licencia,@Usuario,@Contraseña,@Autos_Comprados,@Correo_Electronico)";
                Comando.Parameters.Add("@Id_Cliente", SqlDbType.VarChar).Value = cliente.Id_Cliente;
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
        public void Update(string id,Cliente cliente)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Update Clientes SET Nombre_Completo = @Nombre_Completo, " +
                    "Direccion = @Direccion,Telefono = @Telefono,Presupuesto = @Presupuesto, Correo_Electronico = @Correo_Electronico" +
                    " WHERE N_Identificacion = " + id +";";
                Comando.Parameters.Add("Nombre_Completo", SqlDbType.VarChar).Value = cliente.Nombre_Completo;
                Comando.Parameters.Add("Direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                Comando.Parameters.Add("Telefono", SqlDbType.VarChar).Value = cliente.Telefono;
                Comando.Parameters.Add("Presupuesto", SqlDbType.VarChar).Value = cliente.Presupuesto;
                Comando.Parameters.Add("Correo_Electronico", SqlDbType.VarChar).Value = cliente.Correo_Electronico;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        public void UpdateAuto(string id, Cliente cliente)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Update Clientes SET Presupuesto = @Presupuesto,Autos_Comprados = @Autos_Comprados WHERE Id_Cliente = '" + id + "';";
                Comando.Parameters.Add("Presupuesto", SqlDbType.Int).Value = cliente.Presupuesto;
                Comando.Parameters.Add("Autos_Comprados", SqlDbType.Int).Value = cliente.Autos_Comprados;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        public void Delete(Cliente cliente)
        {
                using (var Comando = conexion.CreateCommand())
                {
                    Comando.CommandText = "Delete FROM clientes WHERE N_Identificacion = @N_Identificacion;";
                    Comando.Parameters.Add("N_Identificacion", SqlDbType.VarChar).Value = cliente.N_Identificacion;
                    Open();
                    Comando.ExecuteNonQuery();
                    Close();
                }
        }

        private Cliente Mapeador_cliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cliente clienteLog = new Cliente();
            clienteLog.Id_Cliente = dataReader.GetString(0);
            clienteLog.N_Identificacion = dataReader.GetInt32(1);
            clienteLog.Nombre_Completo = dataReader.GetString(2);
            clienteLog.Fecha_Nacimiento = dataReader.GetDateTime(3);
            clienteLog.Genero = dataReader.GetString(4);
            clienteLog.Direccion = dataReader.GetString(5);
            clienteLog.Telefono = dataReader.GetString(6);
            clienteLog.Trabaja = dataReader.GetString(7);
            clienteLog.Cargo = dataReader.GetString(8);           
            clienteLog.Presupuesto = dataReader.GetInt32(9);
            clienteLog.Ingresos_Mensuales = dataReader.GetInt32(10);
            clienteLog.Fecha_Registro = dataReader.GetDateTime(11);
            clienteLog.Licencia = dataReader.GetString(12);
            clienteLog.Usuario = dataReader.GetString(13);
            clienteLog.Contraseña = dataReader.GetString(14);
            clienteLog.Autos_Comprados = dataReader.GetInt32(15);
            clienteLog.Correo_Electronico = dataReader.GetString(16);  
            
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

        public DataTable GetBy(String Columna, String DocumentoBuscar)
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from Clientes where " + Columna + " like ('" + DocumentoBuscar + "%')";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }

    }
}
