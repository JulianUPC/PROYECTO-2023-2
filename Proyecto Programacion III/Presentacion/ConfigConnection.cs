using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario_J_M
{
    public static class configConnnection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConcesionarioConnection"].ConnectionString;
    }
}
