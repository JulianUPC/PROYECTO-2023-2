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
        public void Insert(Empleado empleado)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Empleados (ID_Empleado,N_identificacion,Nombre_Completo,Fecha_Ingreso,Pago_Mes,Monto_Comision,Cargo) values (@ID_Empleado,@N_identificacion,@Nombre_Completo,@Fecha_Ingreso,@Pago_Mes,@Monto_Comision,@Cargo)";
                Comando.Parameters.Add("@ID_Empleado", SqlDbType.VarChar).Value = empleado.ID_Empleado;
                Comando.Parameters.Add("@N_identificacion", SqlDbType.VarChar).Value = empleado.N_identificacion;
                Comando.Parameters.Add("@Nombre_Completo", SqlDbType.VarChar).Value = empleado.Nombre_Completo;
                Comando.Parameters.Add("@Fecha_Ingreso", SqlDbType.DateTime).Value = empleado.Fecha_Ingreso;
                Comando.Parameters.Add("@Pago_Mes", SqlDbType.Int).Value = empleado.Pago_Mes;
                Comando.Parameters.Add("@Monto_Comision", SqlDbType.Int).Value = empleado.Monto_Comision;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = empleado.Cargo;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        public void Update(string id,Empleado empleado)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Update Empleados SET Pago_Mes = @Pago_Mes,Monto_Comision = @Monto_Comision WHERE ID_Empleado = '" + id + "';";
                Comando.Parameters.Add("@Pago_Mes", SqlDbType.Int).Value = empleado.Pago_Mes;
                Comando.Parameters.Add("@Monto_Comision", SqlDbType.Int).Value = empleado.Monto_Comision;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        public void Delete(Empleado empleado)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Delete FROM Empleados WHERE ID_Empleado = @ID_Empleado;";
                Comando.Parameters.Add("ID_Empleado", SqlDbType.VarChar).Value = empleado.ID_Empleado;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        private Empleado Mapeador_empleado(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Empleado EmpleadoLog = new Empleado();
            EmpleadoLog.ID_Empleado = dataReader.GetString(0);
            EmpleadoLog.N_identificacion = dataReader.GetString(1);
            EmpleadoLog.Nombre_Completo = dataReader.GetString(2);
            EmpleadoLog.Fecha_Ingreso = dataReader.GetDateTime(3);
            EmpleadoLog.Pago_Mes = dataReader.GetInt32(4);
            EmpleadoLog.Monto_Comision = dataReader.GetInt32(5);

            return EmpleadoLog;
        }
        public List<Empleado> GetAll()
        {
            List<Empleado> empleado = new List<Empleado>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM EMPLEADOS";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                empleado.Add(Mapeador_empleado(lector));
            }
            Close();
            return empleado;
        }
        public DataTable GetBy(String Columna, String DocumentoBuscar)
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from Empleados where " + Columna + " like ('" + DocumentoBuscar + "%')";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }
        public DataTable GetAllTabla()
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM EMPLEADOS";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }
    }
}
