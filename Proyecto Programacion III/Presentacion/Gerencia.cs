using Entidades;
using Logica2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concesionario_J_M
{
    public partial class Gerencia : Form
    {
        ServicioAutos servicioAutos = new ServicioAutos(configConnnection.ConnectionString);
        Servicio_Ventas servicioVentas = new Servicio_Ventas();
        Servicio_Finanzas servicioFinanzas = new Servicio_Finanzas();
        Servicio_Empleado servicioEmpleado = new Servicio_Empleado(configConnnection.ConnectionString);
        ServicioClientes servicioClientes = new ServicioClientes(configConnnection.ConnectionString);
        public Gerencia()
        {
            InitializeComponent();
            Contadores();
        }
        //ABRIR Y CERRAR PANELES DEPENDIENDO LA OPCION
        //PANEL CLIENTES
        private void Cerrar_Paneles()
        {
            Panel_Empleados.Visible = false;
            Panel_Finanzas.Visible = false;
            Panel_Ventas.Visible = false;
            Panel_Inventario.Visible = false;
        }
       private void Contadores()
        {
            Total_Clientes.Text = servicioClientes.ContarClientes().ToString(); 
            lbl_TotalEmpleado.Text = servicioEmpleado.ContarEmpleados().ToString();
            lbl_VehiculosTotal.Text = servicioAutos.ContarAutos().ToString();
            //servicioVentas.Contar_VehiculosVendidos();
            //servicioAutos.Contar_VehiculosInventario();

        }

        //PANEL EMPLEADOS
        private void Cerrar_PanelesEmpleados()
        {
            Panel_Empleados.Visible = true;
            Panel_Finanzas.Visible = false;
            Panel_Ventas.Visible = false;
            Panel_Inventario.Visible = false;         
        }
        //PANEL FINANANZAS
        private void Cerrar_PanelesFinanzas()
        {
            Panel_Empleados.Visible = true;
            Panel_Finanzas.Visible = true;
            Panel_Ventas.Visible = false;
            Panel_Inventario.Visible = false;
        }
        //PANEL VENTAS
        private void Cerrar_PanelesVentas()
        {
            Panel_Empleados.Visible = true;
            Panel_Finanzas.Visible = true;
            Panel_Ventas.Visible = true;
            Panel_Inventario.Visible = false;
        }
        //PANEL INVENTARIO
        private void Cerrar_PanelesInventario()
        {
            Panel_Empleados.Visible = true;
            Panel_Finanzas.Visible = true;
            Panel_Ventas.Visible = true;
            Panel_Inventario.Visible = true;
        }
        private void Btn_Clientes_Click(object sender, EventArgs e)
        {
            Cerrar_Paneles();
        }
        private void Btn_Inventario_Click(object sender, EventArgs e)
        {
            Cerrar_PanelesEmpleados();
        }
        private void Btn_Finanzas_Click(object sender, EventArgs e)
        {
            Cerrar_PanelesFinanzas();
        }
        private void Btn_Ventas_Click(object sender, EventArgs e)
        {
            Cerrar_PanelesVentas();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cerrar_PanelesInventario();
        }
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            Panel_ModificarCliente.Visible = true;
        }

        private void Btn_Volver_Click_1(object sender, EventArgs e)
        {
            Panel_ModificarCliente.Visible = false;
        }

        private void Btn_ModificarP_Click(object sender, EventArgs e)
        {
            Panel_ModificarP.Visible = true;
        }

        private void Btn_BorrarV_Click(object sender, EventArgs e)
        {
            Panel_BorrarV.Visible = true;
        }

        private void Btn_VolverM_Click(object sender, EventArgs e)
        {
            Panel_ModificarP.Visible = false;
        }

        private void Btn_VolverB_Click(object sender, EventArgs e)
        {
            Panel_BorrarV.Visible = false;
        }

        private void Btn_ModificarI_Click(object sender, EventArgs e)
        {
            Panel_ModificarI.Visible = true;
        }

        private void btn_BorrarI_Click(object sender, EventArgs e)
        {
            Panel_BorrarI.Visible = true;
        }

        private void Pict_ModificarI_Click(object sender, EventArgs e)
        {
            Panel_ModificarI.Visible = false;
        }

        private void Pict_BorrarI_Click(object sender, EventArgs e)
        {
            Panel_BorrarI.Visible = false;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Autos autos = new Autos();
            autos.Show();
        }

        private void Txt_BuscarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Dtv_Clientes.DataSource = servicioClientes.GetBy("N_Identificacion", Txt_BuscarID.Text);
        }

        private void Btn_ConfModificar_Click(object sender, EventArgs e)
        {
            servicioClientes.ActualizarInfo(Txt_ModNombre, Txt_ModTelefono, Txt_ModDireccion,Txt_ModPresupuesto,Txt_ModCorreo,Txt_BuscarID);
        }

        private void Btn_Borrar_Click(object sender, EventArgs e)
        {
            servicioClientes.Delete(Txt_BuscarID);
            Contadores();
        }

        private void Btn_BorrarEmp_Click(object sender, EventArgs e)
        {
            Contadores();
        }
        //FIN DISEÑO
    }
}
