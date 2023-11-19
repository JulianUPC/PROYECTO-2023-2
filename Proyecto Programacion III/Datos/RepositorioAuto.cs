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
            Auto AutoLog = new Auto();
            AutoLog.Nombre_Auto = dataReader.GetString(0);
            AutoLog.Precio_Compra = dataReader.GetInt32(1);
            AutoLog.Modelo = dataReader.GetString(2);
            AutoLog.Categoria = dataReader.GetString(3);
            AutoLog.Motor = dataReader.GetString(4);
            AutoLog.Potencia = dataReader.GetString(5);
            AutoLog.Valvulas = dataReader.GetString(6);
            AutoLog.Asientos = dataReader.GetString(7);
            AutoLog.Sistema_Combustible = dataReader.GetString(8);
            AutoLog.Tipo_Transmision = dataReader.GetString(9);
            AutoLog.Id_Auto = dataReader.GetString(10);
            AutoLog.Precio_Venta = dataReader.GetInt32(11);

            return AutoLog;
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
