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
        private void Btn_Informacion_Click(object sender, EventArgs e)
        {
            Informacion informacion = new Informacion();
            informacion.Show();
        }
        private void Btn_Inventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
        }

        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Finanzas_Click(object sender, EventArgs e)
        {
            Finanzas finanzas = new Finanzas();
            finanzas.Show();
        }

        private void Btn_Ventas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();   
            ventas.Show();
        }
    }
}
