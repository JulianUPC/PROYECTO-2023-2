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
    public class Repositorio_Ventas : Conexion
    {
        public Repositorio_Ventas(string connectionString) : base(connectionString)
        {
        }
        public void Insert(Ventas ventas)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Ventas (Id_Cliente,Comprador,Nombre_Vendedor,Fecha_Vendido,Precio_Vendido,Id_Auto,Matricula,Nombre_Auto,Categoria,Motor,Potencia,Sistema_Combustible,Tipo_Transmision) values (@Id_Cliente,@Comprador,@Nombre_Vendedor,@Fecha_Vendido,@Precio_Vendido,@Id_Auto,@Matricula,@Nombre_Auto,@Categoria,@Motor,@Potencia,@Sistema_Combustible,@Tipo_Transmision)";
                Comando.Parameters.Add("@Id_Cliente", SqlDbType.VarChar).Value = ventas.Id_Cliente;
                Comando.Parameters.Add("@Comprador", SqlDbType.VarChar).Value = ventas.Comprador;
                Comando.Parameters.Add("@Nombre_Vendedor", SqlDbType.VarChar).Value = ventas.Nombre_Vendedor;
                Comando.Parameters.Add("@Fecha_Vendido", SqlDbType.DateTime).Value = ventas.Fecha_Vendido;
                Comando.Parameters.Add("@Precio_Vendido", SqlDbType.Int).Value = ventas.Precio_Venta;
                Comando.Parameters.Add("@Id_Auto", SqlDbType.VarChar).Value = ventas.Id_Auto;
                Comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = ventas.Matricula;
                Comando.Parameters.Add("@Nombre_Auto", SqlDbType.VarChar).Value = ventas.Nombre_Auto;
                Comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = ventas.Categoria;
                Comando.Parameters.Add("@Motor", SqlDbType.VarChar).Value = ventas.Motor;
                Comando.Parameters.Add("@Potencia", SqlDbType.VarChar).Value = ventas.Potencia;
                Comando.Parameters.Add("@Sistema_Combustible", SqlDbType.VarChar).Value = ventas.Sistema_Combustible;
                Comando.Parameters.Add("@Tipo_Transmision", SqlDbType.VarChar).Value = ventas.Tipo_Transmision;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        private Ventas Mapeador_Ventas(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ventas VentasLog = new Ventas();
            VentasLog.Id_Cliente = dataReader.GetString(0);
            VentasLog.Comprador = dataReader.GetString(1);
            VentasLog.Nombre_Vendedor  = dataReader.GetString(2);
            VentasLog.Fecha_Vendido = dataReader.GetDateTime(3);
            VentasLog.Precio_Venta = dataReader.GetInt32(4);
            VentasLog.Id_Auto = dataReader.GetString(5);
            VentasLog.Matricula = dataReader.GetString(6);
            VentasLog.Nombre_Auto = dataReader.GetString(7);
            VentasLog.Categoria = dataReader.GetString(8);
            VentasLog.Motor = dataReader.GetString(9);
            VentasLog.Potencia = dataReader.GetString(10);
            VentasLog.Sistema_Combustible = dataReader.GetString(11);
            VentasLog.Tipo_Transmision = dataReader.GetString(12);

            return VentasLog;
        }
        private Ventas Mapeador_Auto_Cliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ventas VentasLog = new Ventas();
            VentasLog.Nombre_Vendedor = dataReader.GetString(0);
            VentasLog.Fecha_Vendido = dataReader.GetDateTime(1);
            VentasLog.Precio_Venta = dataReader.GetInt32(2);
            VentasLog.Matricula = dataReader.GetString(3);
            VentasLog.Nombre_Auto = dataReader.GetString(4);
            VentasLog.Categoria = dataReader.GetString(5);
            VentasLog.Motor = dataReader.GetString(6);
            VentasLog.Potencia = dataReader.GetString(7);
            VentasLog.Sistema_Combustible = dataReader.GetString(8);
            VentasLog.Tipo_Transmision = dataReader.GetString(9);

            return VentasLog;
        }
        public List<Ventas> GetAll()
        {
            List<Ventas> ventas = new List<Ventas>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM VENTAS";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ventas.Add(Mapeador_Ventas(lector));
            }
            Close();
            return ventas;
        }
        public DataTable GetAllTabla_Auto_Cliente(string comprador)
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT Nombre_Vendedor,Fecha_Vendido,Precio_Vendido,Matricula,Nombre_Auto,Categoria,Motor,Potencia,Sistema_Combustible,Tipo_Transmision FROM VENTAS where Id_Cliente = '" + comprador + "';";
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
            comando.CommandText = "SELECT * FROM VENTAS";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }
    }
}
