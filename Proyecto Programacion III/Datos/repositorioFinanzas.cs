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
    public class repositorioFinanzas : Conexion 
    {
        public repositorioFinanzas(string connectionString) : base(connectionString)
        {
        }
        private Finanzas Mapeador_finanzas(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Finanzas clienteLog = new Finanzas();
            clienteLog.Tipo = dataReader.GetString(0);
            clienteLog.Fecha_Ingreso = dataReader.GetDateTime(1);
            clienteLog.Monto_Ingreso = dataReader.GetInt32(2);
            clienteLog.Fecha_Gasto = dataReader.GetDateTime(3);
            clienteLog.Monto_Gasto = dataReader.GetInt32(4);
            clienteLog.Nombre_Auto = dataReader.GetString(5);

            return clienteLog;
        }
        public DataTable GetAllT()
        {
            Open();
            SqlCommand comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from FINANCIERO";
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dt);
            Close();
            return dt;
        }
        public List<Finanzas> GetAll()
        {
            List<Finanzas> finanzas = new List<Finanzas>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM FINANCIERO";
            Open();
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                finanzas.Add(Mapeador_finanzas(lector));
            }
            Close();
            return finanzas;
        }

    }
}
