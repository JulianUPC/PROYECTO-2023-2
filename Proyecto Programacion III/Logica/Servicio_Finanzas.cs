using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica2
{
    public class Servicio_Finanzas
    {
        Datos.repositorioFinanzas repositorioFinanzas;
        public Servicio_Finanzas(string conexion)
        {
            repositorioFinanzas = new repositorioFinanzas(conexion);
        }
        public void Insertar(Finanzas finanzas)
        {
            repositorioFinanzas.Insert(finanzas);
        }

        public void Delete(Finanzas finanzas)
        {
            repositorioFinanzas.Delete(finanzas);
        }

        public void Update(string id, Finanzas finanzas)
        {
            repositorioFinanzas.Update(id, finanzas);
        }
        public int Contar_Ingresos()
        {
            int total_ingresos = 0;
            foreach (var item in GetAll())
            {
                total_ingresos = total_ingresos + item.Monto_Ingreso;
            }
            return total_ingresos;
        }
        public int Contar_Gastos()
        {
            int total_gastos = 0;
            foreach (var item in GetAll())
            {
                total_gastos = total_gastos + item.Monto_Gasto;
            }
            return total_gastos;
        }
        public int Contar_DineroTotal()
        {
            int dinero_total = 0;
            dinero_total = Contar_Ingresos() - Contar_Gastos();
            return dinero_total;
        }
        public List<Finanzas> GetAll()
        {
                return repositorioFinanzas.GetAll();                
        }
    }
}
