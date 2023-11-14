using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gerente : Cliente
    {
        public Gerente() { }
        public Gerente(bool modo_Gerente,string usuario,string contraseña)
        {
            Usuario = usuario;
            Contraseña = contraseña;
        }
    }
}
