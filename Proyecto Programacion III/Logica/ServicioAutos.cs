﻿using Datos;
using Entidades;
using System;
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
        Datos.RepositorioInventario repositorioInventario;
        Datos.repositorioFinanzas repositorioFinanzas;
        Inventario inventario = new Inventario();
        Finanzas finanzas = new Finanzas();
        Auto auto = new Auto();
        Servicio_Inventario servicio_Inventario;
        Servicio_Finanzas servicio_Finanzas;
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
        public void ActualizarPrecio(TextBox id_auto,TextBox precio)
        {
            try
            {
                if (string.IsNullOrEmpty(id_auto.Text) || string.IsNullOrEmpty(precio.Text))
                {
                    MessageBox.Show("Llene todo los campos para poder modificar");
                }
                else
                {
                    auto.Precio_Venta = int.Parse(precio.Text);
                    Update(id_auto.Text, auto);
                    MessageBox.Show("Precio Actualizado Correctamente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Id del vehiculo no Encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

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
