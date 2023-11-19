using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public interface ICrud<T>
    {
        void Insertar(T Entidad);
        void Delete(T Entidad);
        void Update(string id,T Entidad);
        List<T> GetAll();
    }
}

