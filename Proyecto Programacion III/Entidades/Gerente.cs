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
        public bool Modo_Gerente { get; set; }
        public Gerente(bool modo_Gerente,string usuario,string contraseña)
        {
            Modo_Gerente = modo_Gerente;
            Usuario = usuario;
            Contraseña = contraseña;
        }
    }
}
