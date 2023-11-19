using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica2
{
    public class Manejo_Formulario
    {
        ErrorProvider Validar = new ErrorProvider();

        public void ValidarLetras(KeyPressEventArgs e, System.Windows.Forms.TextBox h)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                Validar.Clear();

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false; Validar.Clear();
            }
            else
            {
                e.Handled = true;
                Validar.SetError(h, "Solo Puede Digitar Letras");
            }
        }
        public ErrorProvider validarN(KeyPressEventArgs e, System.Windows.Forms.TextBox h)
        {
            bool error = SoloNumeros(e);
            if (!error)
            {
                Validar.SetError(h, "Solo Puede Digitar Numeros");
                return null;
            }
            else
            {
                Validar.Clear();
                return null;
            }
        }
        public bool SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false; return true;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false; return true;
            }
            else
            {
                e.Handled = true; return false;
            }
        }
        public void LimitarLongitudTextBox(TextBox textBox, int longitudMaxima, KeyPressEventArgs e)
        {
            if (textBox.Text.Length >= longitudMaxima && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        public void ValidarTerminos(RadioButton terminossi,RadioButton terminosno)
        {
            if(terminossi.Checked)
            {
                
            }
            else if(terminosno.Checked)
            {
                MessageBox.Show("Debe Aceptar Los Terminos y Condiciones");
            }
        }
        public void OcultarFilasVacias(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool filaVacia = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        filaVacia = false;
                        break; 
                    }
                }
                row.Visible = !filaVacia;
            }
        }

    } 
}
