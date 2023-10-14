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
        public Gerencia()
        {
            InitializeComponent();
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
        //PANEL EMPLEADOS
        private void Cerrar_PanelesEmpleados()
        {
            Panel_Ventas.Visible = false;
            Panel_Inventario.Visible = false;
            Panel_Empleados.Visible = true;
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
            this.Close();
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Autos autos = new Autos();
            autos.Show();
        }
    }
}
