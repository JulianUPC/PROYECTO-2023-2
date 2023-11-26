using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void Letras_Grises(Button boton)
        {
            boton.BackColor = Color.Gainsboro; //SI EL MOUSE SALE DEL BOTON 
            boton.ForeColor = Color.DimGray;
        }
        public void Letras_Negras(Button boton)
        {
            boton.BackColor = Color.White;
            boton.ForeColor = Color.Black; //SI EL MOUSE PASA POR EL BOTON 
        }
        public void ConvertirALetrasDeContrasena(TextBox textBox)
        {
            textBox.PasswordChar = '●';
        }
        public bool Abrir_Form(Panel detalles,Label nombre,Label dinero_dispo,Form menu,Form gerencia)
        {
            bool Salir = false;
            if (detalles.Visible == true)
            {
                detalles.Visible = false;
            }
            else
            {
                if (nombre.Text == "Perfil Sesion")
                {                  
                    menu.Show(); 
                    Salir = true;
                }
                else if (nombre.Text == "Gerente")
                {
                    if (Mensaje_SalirGerente() == true)
                    {
                        nombre.Text = "";
                        nombre.Visible = false;
                        dinero_dispo.Text = "0";
                        gerencia.Show();
                        Salir = true;
                    }
                }
                else
                {
                    if (Mensaje_Salir() == true)
                    {
                        nombre.Text = "";
                        nombre.Visible = false;
                        dinero_dispo.Text = "0";
                        menu.Show();
                        Salir = true;
                    }
                }
            }
            return Salir;
        }
        public bool Mensaje_Salir()
        {
            DialogResult Resultado = MessageBox.Show("Esta sesion se cerrara \n ¿Seguro Desea Salir? ", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultado == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Mensaje_SalirGerente()
        {
            DialogResult Resultado = MessageBox.Show("Volvera al menu de gerencia \n     ¿Seguro Desea Salir? ", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultado == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
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
