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
                Comando.CommandText = "Insert into Ventas (Id_Cliente,Nombre_Vendedor,Comprador,Fecha_Vendido,Precio_Vendido,Id_Auto,Matricula,Nombre_Auto,Categoria,Motor,Potencia,Sistema_Combustible,Tipo_Transmision) values (@Id_Cliente,@Comprador,@Nombre_Vendedor,@Fecha_Vendido,@Precio_Vendido,@Id_Auto,@Matricula,@Nombre_Auto,@Categoria,@Motor,@Potencia,@Sistema_Combustible,@Tipo_Transmision)";
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
            Ventas clienteLog = new Ventas();
            clienteLog.Id_Cliente = dataReader.GetString(0);
            clienteLog.Comprador = dataReader.GetString(1);
            clienteLog.Nombre_Vendedor  = dataReader.GetString(2);
            clienteLog.Fecha_Vendido = dataReader.GetDateTime(3);
            clienteLog.Precio_Venta = dataReader.GetInt32(4);
            clienteLog.Id_Auto = dataReader.GetString(5);
            clienteLog.Matricula = dataReader.GetString(6);
            clienteLog.Nombre_Auto = dataReader.GetString(7);
            clienteLog.Categoria = dataReader.GetString(8);
            clienteLog.Motor = dataReader.GetString(9); 
            clienteLog.Potencia = dataReader.GetString(10);
            clienteLog.Sistema_Combustible = dataReader.GetString(11);
            clienteLog.Tipo_Transmision = dataReader.GetString(12);

            return clienteLog;
        }
        private Ventas Mapeador_Auto_Cliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ventas clienteLog = new Ventas();
            clienteLog.Nombre_Vendedor = dataReader.GetString(0);
            clienteLog.Fecha_Vendido = dataReader.GetDateTime(1);
            clienteLog.Precio_Venta = dataReader.GetInt32(2);
            clienteLog.Matricula = dataReader.GetString(3);
            clienteLog.Nombre_Auto = dataReader.GetString(4);
            clienteLog.Categoria = dataReader.GetString(5);
            clienteLog.Motor = dataReader.GetString(6);
            clienteLog.Potencia = dataReader.GetString(7);
            clienteLog.Sistema_Combustible = dataReader.GetString(8);
            clienteLog.Tipo_Transmision = dataReader.GetString(9);

            return clienteLog;
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
        public List<Ventas> GetByAuto_Cliente(string comprador)
        {
            List<Ventas> ventas = new List<Ventas>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT Fecha_Vendido,Precio_Vendido,Matricula,Nombre_Auto,Categoria,Motor,Potencia,Sistema_Combustible,Tipo_Transmision FROM VENTAS where Id_Cliente = '"+comprador+"';";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ventas.Add(Mapeador_Auto_Cliente(lector));
            }
            Close();
            return ventas;
        }
    }
}
