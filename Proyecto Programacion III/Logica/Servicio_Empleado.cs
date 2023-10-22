using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class Servicio_Empleado : ICrud<Empleado>
    {
        Datos.RepositorioEmpleados repositorioEmpleados;
        public Servicio_Empleado(string conexion)
        {
            repositorioEmpleados = new RepositorioEmpleados(conexion);
        }
        public void ObtenerIdentificacion(string usuario)
        {

        }
        public void Insertar(Empleado Entidad)
        {

        }
        public void Update(string id, Empleado Entidad)
        {

        }
        public void Delete(Empleado Entidad)
        {

        }
        public int ContarEmpleados()
        {
            int total_empleados = 0;

            return total_empleados;
        }
        public List<Empleado> GetAll()
        {
            return null;
        }   
    }
}
