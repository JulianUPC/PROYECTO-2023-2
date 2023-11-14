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
    public class RepositorioAuto_de_Cliente : Conexion
    {
        public RepositorioAuto_de_Cliente(string connectionString) : base(connectionString)
        {
        }

        public void Insert(Autos_de_Clientes autos_de_clientes)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into AUTOS_DE_CLIENTES (Id_Cliente,Id_Auto,Nombre_Auto,Modelo,Categoria,Motor,Potencia,Valvulas,Asientos,Sistema_Combustible,Tipo_Transmision,Precio_de_Compra) values (@Id_Cliente,@Id_Auto,@Nombre_Auto,@Modelo,@Categoria,@Motor,@Potencia,@Valvulas,@Asientos,@Sistema_Combustible,@Tipo_Transmision,@Precio_de_Compra)";
                Comando.Parameters.Add("@Id_Cliente", SqlDbType.VarChar).Value = autos_de_clientes.Id_Cliente;
                Comando.Parameters.Add("@Id_Auto", SqlDbType.VarChar).Value = autos_de_clientes.Id_Auto;
                Comando.Parameters.Add("@Nombre_Auto", SqlDbType.VarChar).Value = autos_de_clientes.Nombre_Auto;
                Comando.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = autos_de_clientes.Modelo;
                Comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = autos_de_clientes.Categoria;
                Comando.Parameters.Add("@Motor", SqlDbType.VarChar).Value = autos_de_clientes.Motor;
                Comando.Parameters.Add("@Potencia", SqlDbType.VarChar).Value = autos_de_clientes.Potencia;
                Comando.Parameters.Add("@Valvulas", SqlDbType.VarChar).Value = autos_de_clientes.Valvulas;
                Comando.Parameters.Add("@Asientos", SqlDbType.VarChar).Value = autos_de_clientes.Asientos;
                Comando.Parameters.Add("@Sistema_Combustible", SqlDbType.VarChar).Value = autos_de_clientes.Sistema_Combustible;
                Comando.Parameters.Add("@Tipo_Transmision", SqlDbType.VarChar).Value = autos_de_clientes.Tipo_Transmision;
                Comando.Parameters.Add("@Precio_de_Compra", SqlDbType.Int).Value = autos_de_clientes.Precio_de_Compra;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        private Autos_de_Clientes Mapeador_autos_de_clientes(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Autos_de_Clientes clienteLog = new Autos_de_Clientes();
            clienteLog.Id_Cliente = dataReader.GetString(0);
            clienteLog.Id_Auto = dataReader.GetString(1);
            clienteLog.Nombre_Auto = dataReader.GetString(2);
            clienteLog.Modelo = dataReader.GetString(3);
            clienteLog.Categoria = dataReader.GetString(4);
            clienteLog.Motor = dataReader.GetString(5);
            clienteLog.Potencia = dataReader.GetString(6);
            clienteLog.Valvulas = dataReader.GetString(7);
            clienteLog.Asientos = dataReader.GetString(8);
            clienteLog.Sistema_Combustible = dataReader.GetString(9);
            clienteLog.Tipo_Transmision = dataReader.GetString(10);
            clienteLog.Precio_de_Compra = dataReader.GetInt32(11);

            return clienteLog;
        }
        public List<Autos_de_Clientes> GetAll()
        {
            List<Autos_de_Clientes> auto_de_clientes = new List<Autos_de_Clientes>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM AUTOS_DE_CLIENTES";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                auto_de_clientes.Add(Mapeador_autos_de_clientes(lector));
            }
            Close();
            return auto_de_clientes;
        }
    }
}
