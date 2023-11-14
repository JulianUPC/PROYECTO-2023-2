using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class Servicio_Autos_de_Clientes : ICrud<Autos_de_Clientes>
    {
        Datos.RepositorioAuto_de_Cliente repositorioAuto_De_Cliente;
        public Servicio_Autos_de_Clientes(string conexion)
        {
            repositorioAuto_De_Cliente = new RepositorioAuto_de_Cliente(conexion);
        }
        public void Insertar(Autos_de_Clientes Entidad)
        {

        }
        public void Update(string id, Autos_de_Clientes Entidad)
        {

        }
        public void Delete(Autos_de_Clientes Entidad)
        {

        }
        public List<Autos_de_Clientes> GetAll()
        {
            return repositorioAuto_De_Cliente.GetAll();
        }
    }
}
