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
    public partial class Quienes_Somos : Form
    { 
        //FORM PARA MOSTRAR QUIENES SOMOS
        public Quienes_Somos()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close(); //Cerrar el formulario
        }
    }
}
