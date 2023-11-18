using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms.VisualStyles;
using Entidades;
using Logica2;
using System.Threading;
using Presentacion;

namespace Concesionario_J_M
{
    public partial class Login : Form
    {
        Cliente cliente = new Cliente();
        ServicioClientes Sl = new ServicioClientes(configConnnection.ConnectionString);
        Manejo_Formulario mf = new Manejo_Formulario();
        public Login()
        {
            InitializeComponent();
        }
        
        private void Btn_Registrar_Click(object sender, EventArgs e)
        {

            Btn_InicioSesion.BackColor = Color.White;
            Btn_InicioSesion.ForeColor = Color.Black;
            Btn_Registrar.BackColor = Color.Black;
            Btn_Registrar.ForeColor = Color.White;
            Panel_Gerente.Visible = false;
            Panel_Registrar.Visible = true;
        }

        private void Btn_InicioSesion_Click(object sender, EventArgs e)
        {
            Btn_InicioSesion.BackColor = Color.Black;
            Btn_InicioSesion.ForeColor = Color.White; 
            Btn_Registrar.BackColor = Color.White; 
            Btn_Registrar.ForeColor = Color.Black;
            Panel_Registrar.Visible = false;
            Panel_Registro2.Visible = false;
            Panel_Gerente.Visible = false;
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            Panel_Registro2.Visible = true;
        }

        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Panel_Registro2.Visible = false;
        }

        private void Btn_Gerente_Click(object sender, EventArgs e)
        {
            Panel_Gerente.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           Presentacion.Menu menu = new Presentacion.Menu();
           menu.Show();
           this.Close();
        }
        private void Txt_NombreC_KeyPress(object sender, KeyPressEventArgs e)
        {
            mf.ValidarLetras(e, Txt_NombreC);
        }

        private void Txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            mf.SoloNumeros(e);
            mf.LimitarLongitudTextBox(Txt_Cedula, 10, e);
        }

        private void Txt_Cargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            mf.ValidarLetras(e, Txt_Cargo);
        }

        private void Txt_IngresosM_KeyPress(object sender, KeyPressEventArgs e)
        {
            mf.SoloNumeros(e);
        }

        private void Txt_Presupuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            mf.SoloNumeros(e);
        }
        //FIN DISEÑO
        //INICIO LOGICA
        private void Btn_RegistrarInfo_Click(object sender, EventArgs e)
        {
            cliente.Id_Cliente = Sl.Generar_ID();
            cliente.N_Identificacion = Sl.Verificar_ID(Txt_Cedula);
            cliente.Nombre_Completo = Txt_NombreC.Text;
            cliente.Fecha_Nacimiento = Dtt_FechaN.Value;
            cliente.Genero = Sl.Verificar_Genero(Opc_Masculino,Opc_Femenino);
            cliente.Direccion = Txt_Direccion.Text;
            cliente.Telefono = Txt_Celular.Text;
            cliente.Trabaja = Sl.Verificar_Trabajo(Opc_TrabajoSi,Opc_TrabajoNo);
            cliente.Cargo = Txt_Cargo.Text;
            cliente.Presupuesto = Sl.LimitesPresupuesto(Txt_Presupuesto);
            cliente.Ingresos_Mensuales = Sl.LimiteIngresos(Txt_IngresosM);
            cliente.Ingresos_Mensuales = Sl.Verificar_Ingresos(Txt_IngresosM);
            cliente.Presupuesto = Sl.Verificar_Presupuesto(Txt_Presupuesto);
            cliente.Fecha_Registro = DateTime.Now;
            cliente.Licencia = Sl.Verificar_Licencia(Opc_LicenciaSi,Opc_LicenciaNo);
            cliente.Usuario = Txt_UsuarioR.Text;
            cliente.Contraseña = Sl.VerificarContraseña(Txt_ContraseñaR, Txt_ConfCotraseñaR);
            cliente.Autos_Comprados = 0;
            if(txt_Correo.Text == "")
            {
                txt_Correo.Text = "Sin Correo";
            }
            cliente.Correo_Electronico = txt_Correo.Text;           
            Sl.Registrar(cliente,Opc_TerminosSi,Opc_TerminosNo,Panel_Registrar,Panel_Registro2,Txt_Cedula,Txt_NombreC,Txt_Direccion,Txt_Celular,Txt_Cargo,Txt_IngresosM,Txt_Presupuesto,txt_Correo,Txt_UsuarioR,Txt_ContraseñaR,Txt_ConfCotraseñaR,Opc_Femenino,Opc_Masculino,Opc_TrabajoSi,Opc_TrabajoNo,Opc_LicenciaSi,Opc_LicenciaNo,Opc_TerminosSi,Opc_TerminosNo,Dtt_FechaN);
            
        }
        //INICIO DE SESION
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            Txt_Cedula.Text = Sl.Iniciar_Sesion(Txt_Usuario, Txt_Contraseña);
            Console.WriteLine(Txt_Cedula.Text);
            if (Sl.Buscar_Cuenta(Txt_Cedula) == true)
            {                     
                Autos autos = new Autos();
                autos.PasarUsuario(Txt_Cedula.Text);
                autos.Show();            
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos");
            }
        }      
        private void Btn_IngresarGerente_Click(object sender, EventArgs e)
        {
            if (Sl.IngresarGerente(Txt_UsuarioG, Txt_ContraseñaG) == true)
            {
                Gerencia gerencia = new Gerencia();
                gerencia.Show();
                this.Close();
            }
        }
    }
}
