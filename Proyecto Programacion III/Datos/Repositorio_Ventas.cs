using Entidades;
using System;
using System.Collections.Generic;
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
        private Ventas Mapeador_Ventas(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ventas clienteLog = new Ventas();
            clienteLog.Fecha_Vendido = dataReader.GetDateTime(0);
            clienteLog.Id_Cliente = dataReader.GetString(1);
            clienteLog.Id_Auto = dataReader.GetString(2);
            clienteLog.Matricula = dataReader.GetString(3);
            clienteLog.Nombre_Auto = dataReader.GetString(4);
            clienteLog.Precio_Venta = dataReader.GetInt32(5);
            clienteLog.Modelo = dataReader.GetString(6);
            clienteLog.Categoria = dataReader.GetString(7);
            clienteLog.Motor = dataReader.GetString(8); 
            clienteLog.Potencia = dataReader.GetString(9);
            clienteLog.Valvulas = dataReader.GetString(10);
            clienteLog.Asientos = dataReader.GetString(11);
            clienteLog.Sistema_Combustible = dataReader.GetString(12);
            clienteLog.Tipo_Transmision = dataReader.GetString(13);

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
    }
}
