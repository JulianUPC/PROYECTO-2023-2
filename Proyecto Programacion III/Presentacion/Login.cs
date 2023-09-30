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

namespace Concesionario_J_M
{
    public partial class Login : Form
    {
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
    }
}
