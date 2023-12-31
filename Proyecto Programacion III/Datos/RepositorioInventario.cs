﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioInventario : Conexion
    {
        public RepositorioInventario(string connectionString) : base(connectionString)
        {
        }
        public void Insert(Inventario inventario)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Inventario (Fecha_Compra,Matricula,Nombre_Auto,Precio_Venta,Modelo,Categoria,Motor,Potencia,Valvulas,Asientos,Sistema_Combustible,Tipo_Transmision,Id_Auto) values (@Fecha_Compra,@Matricula,@Nombre_Auto,@Precio_Venta,@Modelo,@Categoria,@Motor,@Potencia,@Valvulas,@Asientos,@Sistema_Combustible,@Tipo_Transmision,@Id_Auto)";
                Comando.Parameters.Add("@Fecha_Compra", SqlDbType.DateTime).Value = inventario.Fecha_Compra;
                Comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = inventario.Matricula;
                Comando.Parameters.Add("@Nombre_Auto", SqlDbType.VarChar).Value = inventario.Nombre_Auto;
                Comando.Parameters.Add("@Precio_Venta", SqlDbType.Int).Value = inventario.Precio_Venta;
                Comando.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = inventario.Modelo;
                Comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = inventario.Categoria;
                Comando.Parameters.Add("@Motor", SqlDbType.VarChar).Value = inventario.Motor;
                Comando.Parameters.Add("@Potencia", SqlDbType.VarChar).Value = inventario.Potencia;
                Comando.Parameters.Add("@Valvulas", SqlDbType.VarChar).Value = inventario.Valvulas;
                Comando.Parameters.Add("@Asientos", SqlDbType.VarChar).Value = inventario.Asientos;
                Comando.Parameters.Add("@Sistema_Combustible", SqlDbType.VarChar).Value = inventario.Sistema_Combustible;
                Comando.Parameters.Add("@Tipo_Transmision", SqlDbType.VarChar).Value = inventario.Tipo_Transmision;
                Comando.Parameters.Add("@Id_Auto", SqlDbType.VarChar).Value = inventario.Id_Auto;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        public void Delete(Inventario inventario)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Delete FROM Inventario WHERE Matricula = @Matricula;";
                Comando.Parameters.Add("Matricula", SqlDbType.VarChar).Value = inventario.Matricula;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        public void Update(string id, Inventario inventario)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Update Inventario SET Precio_Venta = @Precio_Venta WHERE Id_Auto = '" + id + "';";
                Comando.Parameters.Add("@Precio_Venta", SqlDbType.Int).Value = inventario.Precio_Venta;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }

        private Inventario Mapeador_inventario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Inventario InventarioLog = new Inventario();
            InventarioLog.Fecha_Compra = dataReader.GetDateTime(0);
            InventarioLog.Matricula = dataReader.GetString(1);
            InventarioLog.Nombre_Auto = dataReader.GetString(2);
            InventarioLog.Precio_Venta = dataReader.GetInt32(3);
            InventarioLog.Modelo = dataReader.GetString(4);
            InventarioLog.Categoria = dataReader.GetString(5);
            InventarioLog.Motor = dataReader.GetString(6);
            InventarioLog.Potencia = dataReader.GetString(7);
            InventarioLog.Valvulas = dataReader.GetString(8);
            InventarioLog.Asientos = dataReader.GetString(9);
            InventarioLog.Sistema_Combustible = dataReader.GetString(10);
            InventarioLog.Tipo_Transmision = dataReader.GetString(11);
            InventarioLog.Id_Auto = dataReader.GetString(12);

            return InventarioLog;
        }
        public List<Inventario> GetAll()
        {
            List<Inventario> inventario = new List<Inventario>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM Inventario";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                inventario.Add(Mapeador_inventario(lector));
            }
            Close();
            return inventario;
        }
        public DataTable GetAllTabla()
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Inventario";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }
    }
}
