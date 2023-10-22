using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        protected SqlConnection conexion;

        public Conexion(string connectionString)
        {
            conexion = new SqlConnection(connectionString);
        }

        public void Open()
        {
            conexion.Open();
        }

        public void Close()
        {
            conexion.Close();
        }
    }
}
