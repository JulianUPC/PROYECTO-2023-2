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
        public void Insert(Finanzas finanzas)
        {
            using (var Comando = conexion.CreateCommand())
            {
                Comando.CommandText = "Insert into Finanzas (Tipo,Fecha_Ingreso,Monto_Ingresos,Fecha_Gasto,Monto_Gastos,Nombre_Auto,Monto_Total) values (@Tipo,@Fecha_Ingreso,@Monto_Ingresos,@Fecha_Gasto,@Monto_Gastos,@Nombre_Auto,@Monto_Total)";
                Comando.Parameters.Add("@Tipo", SqlDbType.DateTime).Value = finanzas.Tipo;
                Comando.Parameters.Add("@Fecha_Ingreso", SqlDbType.VarChar).Value = finanzas.Fecha_Ingreso;
                Comando.Parameters.Add("@Monto_Ingresos", SqlDbType.Int).Value = finanzas.Monto_Ingreso;
                Comando.Parameters.Add("@Fecha_Gasto", SqlDbType.VarChar).Value = finanzas.Fecha_Gasto;
                Comando.Parameters.Add("@Monto_Gastos", SqlDbType.VarChar).Value = finanzas.Monto_Gasto;
                Comando.Parameters.Add("@Nombre_Auto", SqlDbType.VarChar).Value = finanzas.Nombre_Auto;
                Comando.Parameters.Add("@Monto_Total", SqlDbType.VarChar).Value = finanzas.Monto_Total;
                Open();
                Comando.ExecuteNonQuery();
                Close();

            }
        }
        public void Delete(Finanzas finanzas)
        {
        }
        public void Update(string id, Finanzas finanzas)
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
            clienteLog.Monto_Total = dataReader.GetInt32(6);

            return clienteLog;
        }
        public List<Finanzas> GetAll()
        {
            List<Finanzas> finanzas = new List<Finanzas>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM FINANZAS";
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
