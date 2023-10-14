using Concesionario_J_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Menu : Form
    {            
        public Menu()
        {
            InitializeComponent();
            Gerencia ger = new Gerencia();
            ger.Show();
        }
        //CERRAR,MAXIMIZAR,MINIMIZAR
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_AgrandarP_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Btn_AgrandarP.Visible = false;
            Btn_MinimizarP.Visible = true;
        }
        private void Btn_MinimizarP_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Btn_AgrandarP.Visible = true;
            Btn_MinimizarP.Visible = false;
        }
        //FORM ¿QUIENES SOMOS?

        private void Btn_QuienesS_Click(object sender, EventArgs e)
        {
            Quienes_Somos QS = new Quienes_Somos();
            QS.Show();
        }
        private void Btn_QuienesS_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_QuienesS);
        }
        private void Btn_QuienesS_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_QuienesS);
        }

        //FORM AUTOS
        private void Btn_Autos_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_Autos);

        }

        private void Btn_Autos_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_Autos);
        }

        //FORM CONTACTOS
        private void Btn_Contacto_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_Contacto);
        }

        private void Btn_Contacto_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_Contacto);
        }
        //FORM LOGIN
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void Boton_Negro(Button boton)
        {
            boton.BackColor = Color.Black;
            boton.ForeColor = Color.White;
        }
        private void Boton_Blanco(Button boton)
        {
            boton.BackColor = Color.White;
            boton.ForeColor = Color.Black;
        }

        private void Btn_Ingresar_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_Ingresar);

        }

        private void Btn_Ingresar_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_Ingresar);
        }
        private void Form_Autos()
        {
            Autos autos = new Autos();
            autos.Show();
            this.Hide();
            
        }

        private void Btn_Autos_Click(object sender, EventArgs e)
        {  
            Form_Autos();
        }

        private void Btn_Contacto_Click(object sender, EventArgs e)
        {
            TrabajaConNosotros contactanos = new TrabajaConNosotros();
            contactanos.Show();
        }

        private void Btn_ExplorarV_Click(object sender, EventArgs e)
        {
            Form_Autos();
        }
    }
}
