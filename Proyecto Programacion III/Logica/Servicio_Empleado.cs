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
    public class Servicio_Empleado : ICrud<Empleado>
    {
        Datos.RepositorioEmpleados repositorioEmpleados;
        Empleado empleado = new Empleado();
        public Servicio_Empleado(string conexion)
        {
            repositorioEmpleados = new RepositorioEmpleados(conexion);
        }
        public void Insertar(Empleado empleado)
        {
            repositorioEmpleados.Insert(empleado);
        }
        public void Update(string id, Empleado empleado)
        {
            repositorioEmpleados.Update(id,empleado);
        }
        public void Delete(Empleado empleado)
        {
            repositorioEmpleados.Delete(empleado);
        }
        public void Registrar(Empleado empleado)
        {
            if (RevisarDatos(empleado) == true)
            {
                if (Buscar_Repetidos(empleado) == false)
                {
                    Insertar(empleado);
                    MessageBox.Show("Empleado Contratado");
                }
            }
        }
        public bool RevisarDatos(Empleado empleado)
        {
            bool validacion = true;
            if(string.IsNullOrEmpty(empleado.ID_Empleado))
            {
                MessageBox.Show("El campo ID_Empleado no puede estar vacio.");
                validacion = false;
            }
            else if(string.IsNullOrEmpty(empleado.N_identificacion))
            {
                MessageBox.Show("El campo N_identificacion no puede estar vacio.");
                validacion = false;
            }
            else if (string.IsNullOrEmpty(empleado.Nombre_Completo))
            {
                MessageBox.Show("El campo Nombre_Completo no puede estar vacio.");
                validacion = false;
            }
            return validacion;
        }

        public bool Buscar_Repetidos(Empleado empleado)
        {
            bool Verificar = false;
            foreach (var item in GetAll())
            {
                if (item.ID_Empleado.Equals(empleado.ID_Empleado))
                {
                    Verificar = true;
                }
                if (item.N_identificacion.Equals(empleado.N_identificacion))
                {
                    Verificar = true;
                }
            }
            if(Verificar == true)
            {
                MessageBox.Show("ID / Numero de identificacion del empleado ya se encuentra registrado","Error al Registrar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return Verificar;
        } 
        public bool Mensaje_Despido()
        {
           DialogResult mensaje = MessageBox.Show("Seguro quiere despedir a este empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(mensaje == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(TextBox id)
        {
                
            foreach (var item in GetAll()) 
            {
                if (item.ID_Empleado.Equals(id.Text))
                {
                     if (Mensaje_Despido() == true)
                     {
                         empleado.ID_Empleado = item.ID_Empleado;
                         repositorioEmpleados.Delete(empleado);
                         MessageBox.Show("Empleado Despedido");
                     }
                }
            }               
                           
        }
        public int ContarEmpleados()
        {
            int total_empleados = 0;
            foreach (var item in GetAll())
            {
                total_empleados++;
            }
            return total_empleados;
        }
        public string Obtener_Empleado()
        {
           Random random = new Random();
           List<Empleado> empleados = GetAll();
           Empleado empleadoazar = empleados.OrderBy(emp => random.Next()).FirstOrDefault();
           if(empleadoazar == null)
           {
                MessageBox.Show("No se encontraron Vendedores que te puedan atender\nPor favor, informa al ascesor de contratar empleados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "Sin Vendedor Disponible";
           }
           else if (empleadoazar.Cargo == "Gerente")
           {
              Obtener_Empleado();
           }
            return empleadoazar.Nombre_Completo;
        }
        public void Añadir_Comision(string nombre_empleado,int auto_vendido)
        {
            foreach(var item in GetAll())
            {
                if (item.Nombre_Completo.Equals(nombre_empleado))
                {       
                    item.Monto_Comision += empleado.Calcular_Comision(auto_vendido);
                    item.Pago_Mes += item.Monto_Comision;
                    Update(item.ID_Empleado.ToString(),item);
                }
                  
            }
        }


        public List<Empleado> GetAll()
        {
            return repositorioEmpleados.GetAll();
        }
        public DataTable GetBy(String Columna, String Doc)
        {
            return repositorioEmpleados.GetBy(Columna, Doc);
        }
        public DataTable GetAllTabla()
        {
            return repositorioEmpleados.GetAllTabla();
        }
    }

}
