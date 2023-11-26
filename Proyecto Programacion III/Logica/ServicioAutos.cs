using Datos;
using Entidades;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica2
{
    public class ServicioAutos : ICrud<Auto>
    {

        Datos.RepositorioAuto repositorioAutos;
        Auto auto = new Auto();
        public ServicioAutos(string conexion)
        {
            repositorioAutos = new RepositorioAuto(conexion);
        }
        public void Insertar(Auto auto)
        {
            //POR SI EN UN FUTURO SE QUIERE INCLUIR MAS AUTOS
        }
        public void Update(string id,Auto auto)
        {
            repositorioAutos.Update(id,auto);
        }
        public void Delete(Auto auto)
        {
            //POR SI EN UN FUTURO SE QUIERE ELIMINAR AUTOS
        }
        public int ContarAutos() 
        {
            int total_autos = 0;
            foreach (var item in GetAll())
            {
                total_autos++;
            }
            return total_autos;
        }
        public List<Auto> Buscar_Auto(string id_auto)
        {
            try
            {
                List<Auto> ListaPorIA = new List<Auto>();
                if (GetAll() == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in GetAll())
                    {
                        if (item.Id_Auto.Equals(id_auto))
                        {
                            ListaPorIA.Add(item);
                        }
                    }
                }
                return ListaPorIA;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool ActualizarPrecio(TextBox id_auto,TextBox precio)
        {
            bool Actualizar = false;
            bool Encontro = false;
            try
            {
                if (string.IsNullOrEmpty(id_auto.Text) || string.IsNullOrEmpty(precio.Text))
                {
                    MessageBox.Show("Llene todo los campos para poder modificar");
                }
                else
                { 
                    foreach (var item in GetAll())
                    {
                        if (item.Id_Auto.Equals(id_auto.Text))
                        {
                            auto.Precio_Venta = int.Parse(precio.Text);
                            Update(id_auto.Text, auto);
                            MessageBox.Show("Precio Actualizado Correctamente");
                            Encontro = true;
                            Actualizar = true;
                            break;
                        }                     
                    }
                    if (Encontro == false)
                    {
                        MessageBox.Show("El Id del vehiculo no se ha podido encontrar");
                    }                   
                }
                return Actualizar;
            }
            catch (Exception)
            {
                MessageBox.Show("Id del vehiculo no Encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Actualizar;
            }
            

        }
        public async void Proceso_Compra(Panel panel_Compra,Label label1,Label label_punto1,Label label_punto2,Label label_punto3,PictureBox logo,Label comprar_Cmpt,PictureBox logo_Cmpt,Button Cerrar,string nombre_vendedor)
        {
            panel_Compra.Visible = true;
            label1.Text = nombre_vendedor;
            await Task.Delay(500);
            label_punto1.Visible = true;
            await Task.Delay(500);
            label_punto2.Visible = true;
            await Task.Delay(500);
            label_punto3.Visible = true;
            await Task.Delay(500);
            logo.Visible = false;
            comprar_Cmpt.Visible = true;
            logo_Cmpt.Visible = true;
            Cerrar.Visible = true;
            label_punto1.Visible = false;
            label_punto2.Visible = false;
            label_punto3.Visible = false;
            logo.Visible = true;
            comprar_Cmpt.Visible = false;
            logo_Cmpt.Visible = false;
        }
        public string Generar_Matricula() 
        {
            for (int i = 0; i < 10; i++)
            {
                Random randomChar = new Random();
                char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                string matriculaRandom = letras[randomChar.Next(26)].ToString() + letras[randomChar.Next(26)].ToString() + letras[randomChar.Next(26)].ToString() + "-" + randomChar.Next(100, 999);

                return matriculaRandom;
            }

            return Generar_Matricula().ToString();
        }
        public bool Comprobar_Saldo(int saldo,int precio)
        {
            int total = saldo - precio;
            if(total < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //MENSAJES
        public bool MensajeInciciarSesion(Form login)
        {
            DialogResult Resultado = MessageBox.Show("Para comprar un vehiculo necesita Iniciar Sesion \n                      ¿Desea Iniciar Sesion? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultado == DialogResult.Yes)
            {
                login.Show();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Mensaje_Comprar()
        {
            DialogResult Resultado = MessageBox.Show("Desea Comprar este Auto?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultado == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       
        //FIN MENSAJES
        public bool Comprar_Auto(string modo_gerente)
        {
            if (modo_gerente == "Gerente")
            {
                return true;                        
            }
            else
            {
                return false;
            }
        }
        public List<Auto> GetAll()
        {
            return repositorioAutos.GetAll();
        }
    }
}
