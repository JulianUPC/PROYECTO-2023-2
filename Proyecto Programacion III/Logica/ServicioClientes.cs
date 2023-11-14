using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica2
{
    public class ServicioClientes : ICrud<Cliente>
    {
        Cliente cliente = new Cliente();
        Datos.RepositorioCliente repositorioCliente;
        ErrorProvider Validar = new ErrorProvider();

        public ServicioClientes(string conexion)
        {
            repositorioCliente = new RepositorioCliente(conexion);
        }
        public void Insertar(Cliente cliente)
        {
            repositorioCliente.Insert(cliente);
        }

        public void Delete(Cliente cliente)
        {
            repositorioCliente.Delete(cliente);
        }

        public void Update(string id,Cliente cliente)
        {
            repositorioCliente.Update(id,cliente);
        }

        public bool AceptarTerminos(RadioButton terminossi,RadioButton terminosno)
        {
            bool validacion = false;
            try
            {
                if(terminossi.Checked == true)
                {
                    validacion = true;
                    terminosno.Checked = false;
                }
                else if(terminosno.Checked)
                {
                    terminossi.Checked = false;
                    validacion = false;
                    Validar.SetError(terminosno,"Debe Aceptar los Terminos y Condiciones");
                }               
            }
            catch
            {

            }
            return validacion;
        }
        public string VerificarContraseña(TextBox contraseña,TextBox ConfContraseña)
        {
            string contraseña_Verificado = "";
            if(contraseña.Text.Equals(ConfContraseña.Text))
            {
                contraseña_Verificado = contraseña.Text;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            return contraseña_Verificado;
        }

        public void ActualizarInfo(TextBox nombre, TextBox telefono, TextBox direccion, TextBox presupuesto, TextBox correo_electronico, TextBox id)
        {
            cliente.Nombre_Completo = nombre.Text;
            cliente.Telefono = telefono.Text;
            cliente.Direccion = direccion.Text;
            cliente.Correo_Electronico = correo_electronico.Text;
            foreach (var item in GetAll())
            {
                if(item.N_Identificacion.Equals(int.Parse(id.Text)))
                {
                    if (string.IsNullOrEmpty(nombre.Text))
                    {
                        cliente.Nombre_Completo = item.Nombre_Completo; ;
                    }
                    if (string.IsNullOrEmpty(telefono.Text))
                    {
                        cliente.Telefono = item.Telefono;
                    }
                    if (string.IsNullOrEmpty(direccion.Text))
                    {
                        cliente.Direccion = item.Direccion;
                    }
                    if (string.IsNullOrEmpty(presupuesto.Text))
                    {
                        cliente.Presupuesto = item.Presupuesto;
                    }
                    else
                    {
                        cliente.Presupuesto = int.Parse(presupuesto.Text);
                    }                
                    if (string.IsNullOrEmpty(correo_electronico.Text))
                    {
                        cliente.Correo_Electronico = item.Correo_Electronico;
                    }
                }
            }          
                Update(id.Text,cliente);
                MessageBox.Show("Informacion Actualizada");             
        }

        public void Delete(TextBox id)
        {
            foreach (var item in GetAll())
            {
                if (item.N_Identificacion.Equals(int.Parse(id.Text)))
                {
                    cliente.N_Identificacion = item.N_Identificacion;
                    repositorioCliente.Delete(cliente);
                    MessageBox.Show("Cliente Eliminado");
                }
            }
        }
        public int LimitesPresupuesto(TextBox presupuesto)
        {
            try
            {
                int total_presupuesto = 0;
                if(string.IsNullOrEmpty(presupuesto.Text))
                {
                    Mensaje_Error();
                    total_presupuesto = 0;
                }
                else if(int.Parse(presupuesto.Text) > 10000000)
                {
                    MessageBox.Show("Limite de Presupuesto alcanzado, Ingrese un Monto valido \n                   ($10000 a $10000000");
                }
                else if (int.Parse(presupuesto.Text) < 10000)
                {
                    MessageBox.Show("Necesita un presupuesto mayor a $10000 para poder registrarse");
                }
                else
                {
                    total_presupuesto = int.Parse(presupuesto.Text);
                }
                return total_presupuesto;
            }
            catch (FormatException)
            {
                return 0;
            }
            
        }

        public int LimiteIngresos(TextBox ingresos)
        {
            int total_ingresos = 0;
            if (string.IsNullOrEmpty(ingresos.Text))
            {
                Mensaje_Error();
                total_ingresos = 0;
            }
            else if(int.Parse(ingresos.Text) > 50000000)
            {
                MessageBox.Show("Limite de Ingresos Mensual alcanzado, Ingrese un Monto valido \n                (5000 - 5000000)");
            }
            else if(int.Parse(ingresos.Text) < 5000)
            {
                MessageBox.Show("Ingreso Mensual muy bajo, Ingrese un Monto valido \n                  (5000 - 5000000)");
            }
            else 
            {
                total_ingresos = int.Parse(ingresos.Text);
            }
            return total_ingresos;
        }
        public string Verificar_Genero(RadioButton hombre,RadioButton mujer)
        {
            string Genero = "";
            if (hombre.Checked)
            {
                Genero =  "Hombre";
            }
            else if (mujer.Checked)
            {
                 Genero = "Mujer";
            }
            return Genero;
        }
        public string Verificar_Licencia(RadioButton licenciasi,RadioButton licenciano)
        {
            string licencia = "";
            if (licenciasi.Checked)
            {
                licencia = "Si";
            }
            else if (licenciano.Checked)
            {
                licencia = "No";
            }
            return licencia;
        }
        public string Verificar_Trabajo(RadioButton si,RadioButton no)
        {
            string Trabajo = "";
            if (si.Checked)
            {
                Trabajo ="Si";
            }
            else if (no.Checked)
            {
                Trabajo ="No";
            }
            return Trabajo;
        }
        public bool Verificar_DatosErroneos(Cliente cliente)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - cliente.Fecha_Nacimiento.Year;
            bool Verificado = true;
            if(cliente.N_Identificacion == 0)
            {
                Mensaje_Error();
                Verificado = false;
            }
            if(string.IsNullOrEmpty(cliente.Nombre_Completo))
            {
                Mensaje_Error();
                Verificado = false;
            }         
            if (edad < 18)
            {
                MessageBox.Show("Debe ser mayor de 18 años para Continuar");
                Verificado = false; 
            }
            if (string.IsNullOrEmpty(cliente.Genero))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Direccion))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Telefono))
            {
                Mensaje_Error();
                Verificado = false;

            }
            if (string.IsNullOrEmpty(cliente.Trabaja))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Cargo))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (cliente.Ingresos_Mensuales == 0) 
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (cliente.Presupuesto == 0)
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Licencia))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Usuario))
            {
                Mensaje_Error();
                Verificado = false;
            }
            if (string.IsNullOrEmpty(cliente.Contraseña))
            {
                Mensaje_Error();
                Verificado = false;
            }

            return Verificado;
        }
        public void Mensaje_Error()
        {
            MessageBox.Show("LLene todas las casillas Para poder Continuar");
        }
        public bool Buscar_Repetidos(Cliente cliente)
        {
            bool Verificar = false;
            foreach (var item in GetAll())
            {
                if (item.N_Identificacion.Equals(cliente.N_Identificacion))
                {
                    Verificar = true;
                }
            }
            return Verificar;
        }
        public int Verificar_ID(TextBox cedula)
        {
            int id = 0;
            if (string.IsNullOrEmpty(cedula.Text))
            {
                id = 0;
            }
            else
            {
                id = int.Parse(cedula.Text);
            }
            return id;
        }

        public int Verificar_Ingresos(TextBox ingresos)
        {
            int total = 0;
            if (string.IsNullOrWhiteSpace(ingresos.Text))
            {
                total = 0;
            }
            else
            {
                total = int.Parse(ingresos.Text);
            }
            return total;
        }

        public int Verificar_Presupuesto(TextBox presupuesto)
        {
            int total = 0;
            if (string.IsNullOrEmpty(presupuesto.Text))
            {
                total = 0;
            }
            else
            {
                total = int.Parse(presupuesto.Text);
            }
            return total;
        }
        public bool Buscar_Cuenta(TextBox identifiacion)
        {
            bool Verificar = false;
            try
            {
                foreach (var item in GetAll())
                {
                    if (item.N_Identificacion.Equals(int.Parse(identifiacion.Text)))
                    {
                        Verificar = true;
                    }
                }
                return Verificar;
            }
            catch (Exception)
            {
                return Verificar;
            }
        }      
        public string Iniciar_Sesion(TextBox usuario,TextBox contraseña)
        {
            string Identificacion="";
            foreach (var item in GetAll())
            {              
                if (item.Usuario.Equals(usuario.Text) & item.Contraseña.Equals(contraseña.Text))
                {
                    Identificacion = item.N_Identificacion.ToString();
                    MessageBox.Show("Sesion iniciada Correctamente");
                    return Identificacion;                  
                }
            }
            return Identificacion;
        }

        public void Registrar(Cliente cliente,RadioButton terminossi,RadioButton terminosno,Panel panel1,Panel panel2,TextBox texto1,TextBox texto2,TextBox texto3,TextBox texto4,TextBox texto5,TextBox texto6,TextBox texto7,TextBox texto8,TextBox texto9,TextBox texto10, TextBox texto11, RadioButton boton1, RadioButton boton2, RadioButton boton3, RadioButton boton4, RadioButton boton5, RadioButton boton6, RadioButton boton7, RadioButton boton8, DateTimePicker fecha_n)
        {
          if (AceptarTerminos(terminossi,terminosno) == true) { 
              if (Verificar_DatosErroneos(cliente) == true)
              {
                    if (Buscar_Repetidos(cliente) == false)
                    {
                          Insertar(cliente);
                          MessageBox.Show("Cuenta Registrada");
                          Vaciar_Registro(panel1,panel2,texto1,texto2,texto3,texto4,texto5,texto6,texto7,texto8,texto9,texto10,texto11,fecha_n);
                          VaciarRadioButtom(boton1,boton2,boton3,boton4,boton5,boton6,boton7,boton8);
                    }
                    else
                    {
                        MessageBox.Show("Este usuario ya se encuentra registrado.");
                    }
              }
          }
        }
        
        public List<Cliente> Buscar_Cliente(string n_identificacion)
        {
            try
            {
                List<Cliente> ListaPorND = new List<Cliente>();
                if (GetAll() == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in GetAll())
                    {
                        if (item.N_Identificacion.Equals(int.Parse(n_identificacion)))
                        {
                            ListaPorND.Add(item);
                        }
                    }
                }
                return ListaPorND;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IngresarGerente(TextBox usuariog,TextBox contraseñag)
        {
            bool Validacion = false;
            if (usuariog.Text == "admin" & contraseñag.Text == "admin")
            {
                Validacion = true;
            }
            else
            {
                Validacion = false;
            }
            return Validacion;
        }
        public int ContarClientes()
        {
            int total_clientes = 0;
            foreach (var item in GetAll())
            {
                total_clientes++;
            }
            return total_clientes;
        }
        public void Vaciar_Registro(Panel panel1,Panel panel2,TextBox texto1, TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7, TextBox texto8, TextBox texto9, TextBox texto10, TextBox texto11, DateTimePicker fecha_n)
        {      
            panel1.Visible = false;
            panel2.Visible = false;
            fecha_n.Text = DateTime.Now.ToString();
            texto1.Text = "";
            texto2.Text = "";
            texto3.Text = "";
            texto4.Text = "";
            texto5.Text = "";
            texto6.Text = "";
            texto7.Text = "";
            texto8.Text = "";
            texto9.Text = "";
            texto10.Text = "";
            texto11.Text = "";
        }

        public void VaciarRadioButtom(RadioButton boton1, RadioButton boton2, RadioButton boton3, RadioButton boton4, RadioButton boton5, RadioButton boton6, RadioButton boton7, RadioButton boton8)
        {
            VaciarRadioButtom(boton1);
            VaciarRadioButtom(boton2);
            VaciarRadioButtom(boton3);
            VaciarRadioButtom(boton4);
            VaciarRadioButtom(boton5);
            VaciarRadioButtom(boton6);
            VaciarRadioButtom(boton7);
            VaciarRadioButtom(boton8);
        }


        public void VaciarTextBox(TextBox txt)
        {
            txt.Text = "";
        }

        public void VaciarRadioButtom(RadioButton radioButton)
        {
            radioButton.Checked = false;
        }
        
        public DataTable GetBy(String Columna, String Doc)
        {
            return repositorioCliente.GetBy(Columna, Doc);
        }

        public List<Cliente> GetAll()
        {
            return repositorioCliente.GetAll();
        }
    }
}
