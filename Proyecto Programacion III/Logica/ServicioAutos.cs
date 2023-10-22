using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class ServicioAutos : ICrud<Auto>
    {
        Datos.RepositorioAuto repositorioAutos;
        public ServicioAutos(string conexion)
        {
            repositorioAutos = new RepositorioAuto(conexion);
        }
        public void ObtenerIdentificacion(string usuario)
        {

        }
        public void Insertar(Auto Entidad)
        {
            
        }
        public void Update(string id,Auto Entidad)
        {

        }
        public void Delete(Auto Entidad)
        {

        }   
        public int ContarAutos()
        {
            int total_autos = 0;
            foreach (var item in GetAll())
            {
                total_autos++;
            }
            return total_autos;
        }
        public List<Auto> GetAll()
        {
            return repositorioAutos.GetAll();
        }
    }
}
