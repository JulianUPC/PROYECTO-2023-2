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
    public class RepositorioAuto : Conexion
    {
        public RepositorioAuto(string connectionString) : base(connectionString)
        {
        }
        public void Update(string id, Auto auto)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Update Autos SET Precio_Venta = @Precio_Venta WHERE ID_Auto = '" + id + "';";
                Comando.Parameters.Add("@Precio_Venta", SqlDbType.Int).Value = auto.Precio_Venta;
                Open();
                Comando.ExecuteNonQuery();
                Close();
            }
        }
        //TENDRA VEHICULOS YA ESTABLECIDOS POR LO CUAL NO HAY NECESIDAD DE LLEVAR INSERT      
        private Auto Mapeador_auto(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Auto clienteLog = new Auto();
            clienteLog.Nombre_Auto = dataReader.GetString(0);
            clienteLog.Precio_Compra = dataReader.GetInt32(1);
            clienteLog.Modelo = dataReader.GetString(2);
            clienteLog.Categoria = dataReader.GetString(3);
            clienteLog.Motor = dataReader.GetString(4);
            clienteLog.Potencia = dataReader.GetString(5);
            clienteLog.Valvulas = dataReader.GetString(6);
            clienteLog.Asientos = dataReader.GetString(7);
            clienteLog.Sistema_Combustible = dataReader.GetString(8);
            clienteLog.Tipo_Transmision = dataReader.GetString(9);
            clienteLog.Id_Auto = dataReader.GetString(10);
            clienteLog.Precio_Venta = dataReader.GetInt32(11);

            return clienteLog;
        }
        public List<Auto> GetAll()
        {
            List<Auto> auto = new List<Auto>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM Autos";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                auto.Add(Mapeador_auto(lector));
            }
            Close();
            return auto;
        }
    }
}
