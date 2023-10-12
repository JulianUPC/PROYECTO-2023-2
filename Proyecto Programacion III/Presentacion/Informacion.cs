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
    public partial class Informacion : Form
    {
        public Informacion()
        {
            InitializeComponent();
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Borrar_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_Borrar);
        }
        private void Btn_Borrar_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_Borrar);
        }
        private void Btn_Modificar_MouseEnter(object sender, EventArgs e)
        {
            Boton_Negro(Btn_Modificar);
        }
        private void Btn_Modificar_MouseLeave(object sender, EventArgs e)
        {
            Boton_Blanco(Btn_Modificar);
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
    }
}
