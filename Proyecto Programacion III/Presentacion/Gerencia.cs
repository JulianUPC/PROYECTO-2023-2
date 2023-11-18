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
        Servicio_Ventas servicioVentas = new Servicio_Ventas(configConnnection.ConnectionString);
        Servicio_Finanzas servicioFinanzas = new Servicio_Finanzas(configConnnection.ConnectionString);
        Servicio_Empleado servicioEmpleado = new Servicio_Empleado(configConnnection.ConnectionString);
        ServicioClientes servicioClientes = new ServicioClientes(configConnnection.ConnectionString);
        Servicio_Inventario servicio_Inventario = new Servicio_Inventario(configConnnection.ConnectionString);
        ServicioAutos servicioAutos = new ServicioAutos(configConnnection.ConnectionString);
        Empleado empleados = new Empleado();
        public Gerencia()
        {
            InitializeComponent();
            Actualizar();
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
            lbl_VehiculosTotal.Text = servicio_Inventario.ContarInventario().ToString();
            lbl_IngresosT.Text = servicioFinanzas.Contar_Ingresos().ToString();
            lbl_GastosT.Text = servicioFinanzas.Contar_Gastos().ToString();
            lbl_DineroTotal.Text = servicioFinanzas.Contar_DineroTotal().ToString();
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
            if (servicioAutos.Mensaje_Salir() == true)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }            
        }
        
        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Autos autos = new Autos();
            autos.ActivarLabelGerente();
            autos.Show();
            this.Close();          
            
        }

        private void Txt_BuscarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Dtv_Clientes.DataSource = servicioClientes.GetBy("N_Identificacion", Txt_BuscarID.Text);
        }

        private void Btn_ConfModificar_Click(object sender, EventArgs e)
        {
            servicioClientes.ActualizarInfo(Txt_ModNombre, Txt_ModTelefono, Txt_ModDireccion,Txt_ModPresupuesto,Txt_ModCorreo,Txt_BuscarID);
            Actualizar();
        }

        private void Btn_Borrar_Click(object sender, EventArgs e)
        {
            servicioClientes.Delete(Txt_BuscarID);
            Actualizar();
        }

        private void Btn_BorrarEmp_Click(object sender, EventArgs e)
        {
            servicioEmpleado.Delete(txt_IDEmpleado);
            Actualizar();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Panel_Contratar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel_Contratar.Visible = true;
        }
        private void Btn_ConfContratar_Click(object sender, EventArgs e)
        {
            empleados.ID_Empleado = Txt_IDCont .Text;
            empleados.N_identificacion = Txt_NIDCont.Text;
            empleados.Nombre_Completo = Txt_NombreCont.Text;
            empleados.Fecha_Ingreso = DateTime.Now;
            empleados.Pago_Mes = 2000;
            empleados.Monto_Comision = 0;
            empleados.Cargo = "Empleado";
            servicioEmpleado.Registrar(empleados);
            Actualizar();
        }

        public void Cargar_Tablas()
        {
            Dtv_Clientes.DataSource = servicioClientes.GetAll();
            Dtv_Empleados.DataSource = servicioEmpleado.GetAll();
            Dtv_IngresosyGastos.DataSource = servicioFinanzas.GetAll();
            Dgv_Ventas.DataSource = servicioVentas.GetAll();
            Dgv_Inventario.DataSource = servicio_Inventario.GetAll();   
            Dtv_Clientes.ReadOnly = true;
            Dtv_Empleados.ReadOnly = true;
            Dtv_IngresosyGastos.ReadOnly = true;
            Dgv_Ventas.ReadOnly = true;
            Dgv_Inventario.ReadOnly = true;
            Dtv_AutosCliente.ReadOnly = true;
        }
        public void Actualizar()
        {
            Contadores();
            Cargar_Tablas();
        }

        private void txt_IDEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Dtv_Empleados.DataSource = servicioEmpleado.GetBy("ID_Empleado", txt_IDEmpleado.Text);
        }

        private void Txt_BuscarM_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Btn_ModificarPA_Click(object sender, EventArgs e)
        {
            servicioAutos.ActualizarPrecio(Txt_ID_Auto,Txt_PrecioM);
            Actualizar();
        }

        private void Dtv_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            servicioClientes.Buscar_Tablas(Txt_BuscarID, Dtv_Clientes, "N_Identificacion", e);
            servicioClientes.Buscar_Tablas(TxT_CompradorID, Dtv_Clientes, "Id_Cliente", e);
            Dtv_AutosCliente.DataSource = servicioVentas.GetAbyAuto_Clientes(TxT_CompradorID.Text);
        }

        private void Dtv_Empleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            servicioClientes.Buscar_Tablas(txt_IDEmpleado, Dtv_Empleados, "ID_Empleado", e);
        }

        private void Dgv_Inventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            servicioClientes.Buscar_Tablas(txt_BuscarMatricula, Dgv_Inventario, "Matricula", e);
        }
    }
}
