using Entidades;
using Logica2;
using Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concesionario_J_M
{
    public partial class Autos : Form
    {
        ServicioClientes Sl = new ServicioClientes(configConnnection.ConnectionString);
        Servicio_Inventario Si = new Servicio_Inventario(configConnnection.ConnectionString);
        ServicioAutos Sa = new ServicioAutos(configConnnection.ConnectionString);
        Servicio_Finanzas Sf = new Servicio_Finanzas(configConnnection.ConnectionString);
        Servicio_Ventas Sv = new Servicio_Ventas(configConnnection.ConnectionString);
        Servicio_Empleado Se = new Servicio_Empleado(configConnnection.ConnectionString);
        Gerencia gerencia = new Gerencia();
        Inventario inventario = new Inventario();
        Finanzas finanzas = new Finanzas();
        Ventas ventas = new Ventas();
        Cliente cliente = new Cliente();

        public Autos()
        {
            InitializeComponent();
            Actualizar_Lista();
        }
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            Presentacion.Menu menu = new Presentacion.Menu();
            if (Panel_Detalles.Visible == true)
            {
                Panel_Detalles.Visible = false;
            }
            else
            {
                if (lbl_Nombre.Text == "Perfil Sesion")
                {
                    menu.Show();
                    this.Close();
                }
                else if (Sa.Mensaje_Salir() == true)
                {
                    if (lbl_Nombre.Text == "Gerente")
                    {
                        lbl_Nombre.Text = "";
                        lbl_Nombre.Visible = false;
                        lbl_DineroDisp.Text = "0";
                        gerencia.Show();
                        gerencia.Actualizar();
                        this.Close();
                    }
                    else
                    {
                        lbl_Nombre.Text = "";
                        lbl_Nombre.Visible = false;
                        lbl_DineroDisp.Text = "0";
                        menu.Show();
                        this.Close();
                    }
                }
            }
        }
        //CODIGO NECESARIO PARA EL COMPORTAMIENTO DEL BOTON AL PASAR EL MOUSE POR ESTE
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
        public void Desactivar_Labels()
        {
            lbl_Camionetas.Visible = false;
            lbl_Convertibles.Visible = false;
            lbl_Deportivos.Visible = false;
            lbl_Electricos.Visible = false;
            lbl_Performance.Visible = false;
        }
        public void BotonesGrises()
        {
            Letras_Grises(Btn_Camionetas);
            Letras_Grises(Btn_Convertibles);
            Letras_Grises(Btn_Deportivos);
            Letras_Grises(Btn_Electricos);
            Letras_Grises(Btn_Performance);
        }
        public void AlterarBorde()
        {
            Btn_Camionetas.FlatAppearance.BorderSize = 1;
            Btn_Convertibles.FlatAppearance.BorderSize = 1;
            Btn_Deportivos.FlatAppearance.BorderSize = 1;
            Btn_Electricos.FlatAppearance.BorderSize = 1;
            Btn_Performance.FlatAppearance.BorderSize = 1;
        }
        public void Comprobrar_Label(Label label, Button boton)
        {
            if (label.Visible == true)
            {

            }
            else
            {
                Letras_Grises(boton);
            }
        }
        public void Ocultar_PanelesCamionetas()
        {
            Panel_Convertibles.Visible = false;
            Panel_Deportivos.Visible = false;
            Panel_Electricos.Visible = false;
        }
        public void Ocultar_PanelesConvertibles()
        {
            Panel_Deportivos.Visible = false;
            Panel_Electricos.Visible = false;
            Panel_Performance.Visible = false;
        }
        public void Ocultar_PanelesDeportivos()
        {
            Panel_Convertibles.Visible = true;
            Panel_Electricos.Visible = false;
            Panel_Performance.Visible = false;
        }
        public void Ocultar_PanelesElectrico()
        {
            Panel_Convertibles.Visible = true;
            Panel_Deportivos.Visible = true;
            Panel_Performance.Visible = false;
        }
        public void MostrarPanel_Performance()
        {
            Panel_Convertibles.Visible = true;
            Panel_Deportivos.Visible = true;
            Panel_Electricos.Visible = true;
        }
        public void Actualizar_Lista()
        {
            Actulizar_Vehiculos(lbl_NCamioneta1, PS_Camioneta1, "A02");
            Actulizar_Vehiculos(lbl_NCamioneta2, PS_Camioneta2, "A09");
            Actulizar_Vehiculos(lbl_NCamioneta3, PS_Camioneta3, "A016");
            Actulizar_Vehiculos(lbl_NCamioneta4, PS_Camioneta4, "A017");
            Actulizar_Vehiculos(lbl_NCamioneta5, PS_Camioneta5, "A018");
            Actulizar_Vehiculos(lbl_NConvertible1, PS_Convertible1, "A015");
            Actulizar_Vehiculos(lbl_NConvertible2, PS_Convertible2, "A01");
            Actulizar_Vehiculos(lbl_NConvertible3, PS_Convertible3, "A012");
            Actulizar_Vehiculos(lbl_NDeportivo1, PS_Deportivo1, "A04");
            Actulizar_Vehiculos(lbl_NDeportivo2, PS_Deportivo2, "A05");
            Actulizar_Vehiculos(lbl_NDeportivo3, PS_Deportivo3, "A013");
            Actulizar_Vehiculos(lbl_NElectrico1, PS_Electrico1, "A03");
            Actulizar_Vehiculos(lbl_NElectrico2, PS_Electrico2, "A08");
            Actulizar_Vehiculos(lbl_NElectrico3, PS_Electrico3, "A010");
            Actulizar_Vehiculos(lbl_NElectrico4, PS_Electrico4, "A011");
            Actulizar_Vehiculos(lbl_NPerformance1, PS_Performance1, "A06");
            Actulizar_Vehiculos(lbl_NPerformance2, PS_Performance2, "A07");
            Actulizar_Vehiculos(lbl_NPerformance3, PS_Performance3, "A014");
        }
        public void Actulizar_Vehiculos(Label Auto, Label precio, string Id_Auto)
        {
            foreach (Auto Ca in Sa.Buscar_Auto(Id_Auto))
            {
                Auto.Text = Ca.Nombre_Auto;
                if (lbl_Nombre.Text == "Gerente")
                {
                    precio.Text = Ca.Precio_Compra.ToString();
                }
                else
                {
                    precio.Text = Ca.Precio_Venta.ToString();
                }

            }

        }


        public void Vehiculo_Detalles(Label Carro, PictureBox picture, string Id_Auto)
        {
            Panel_Detalles.Visible = true;
            Pict_VhcDetalle.Image = picture.Image;
            foreach (Auto Ca in Sa.Buscar_Auto(Id_Auto))
            {
                Carro.Text = Ca.Nombre_Auto;
                lbl_NombreV.Text = Ca.Nombre_Auto;
                lbl_ModeloV.Text = Ca.Modelo;
                lbl_Trasmision.Text = Ca.Tipo_Transmision;
                lbl_SistemaCmb.Text = Ca.Sistema_Combustible;
                lbl_Valvulas.Text = Ca.Valvulas;
                lbl_Motor.Text = Ca.Motor;
                lbl_Asientos.Text = Ca.Asientos;
                lbl_Id_Auto.Text = Ca.Id_Auto;
                if (lbl_Nombre.Text == "Gerente")
                {
                    lbl_Precio.Text = Ca.Precio_Compra.ToString();
                }
                else
                {
                    lbl_Precio.Text = Ca.Precio_Venta.ToString();
                }
            }

        }
        public void Inciar_Sesion()
        {
            Login login = new Login();
            login.Show();
        }

        //CAMIONETAS
        private void Btn_Camionetas_MouseEnter(object sender, EventArgs e)
        {
            Letras_Negras(Btn_Camionetas);  //ENTRADA DE MOUSE EN EL BOTON
        }
        private void Btn_Camionetas_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Camionetas, Btn_Camionetas); //SALIDA DEL MOUSE EN EL BOTON
        }
        private void Btn_Camionetas_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Letras_Negras(Btn_Camionetas);
            AlterarBorde();
            Ocultar_PanelesCamionetas();
            Btn_Camionetas.FlatAppearance.BorderSize = 0;
            lbl_Camionetas.Visible = true;

        }
        private void Pnl_Camioneta1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta1.Visible = true;

        }
        private void Pict_Camioneta1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta1.Visible = true;
        }

        private void Pict_Camioneta2_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta2.Visible = true;
        }

        private void Pict_Camioneta3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta3.Visible = true;
        }

        private void Pict_Camioneta4_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta4.Visible = true;
        }

        private void Pict_Camioneta5_MouseEnter(object sender, EventArgs e)
        {
            lbl_Camioneta5.Visible = true;
        }

        private void Pict_Camioneta1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Camioneta1.Visible = false;
        }

        private void Pict_Camioneta2_MouseLeave(object sender, EventArgs e)
        {
            lbl_Camioneta2.Visible = false;
        }

        private void Pict_Camioneta3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Camioneta3.Visible = false;
        }

        private void Pict_Camioneta4_MouseLeave(object sender, EventArgs e)
        {
            lbl_Camioneta4.Visible = false;
        }

        private void Pict_Camioneta5_MouseLeave(object sender, EventArgs e)
        {
            lbl_Camioneta5.Visible = false;
        }
        //MOSTRAR DETALLES DE LA CAMIONETA

        private void Pict_Camioneta1_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_NCamioneta1, Pict_Camioneta1, "A02");
        }
        private void Pict_Camioneta2_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_NCamioneta2, Pict_Camioneta2, "A09");
        }

        private void Pict_Camioneta3_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_NCamioneta3, Pict_Camioneta3, "A016");
        }

        private void Pict_Camioneta4_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_NCamioneta4, Pict_Camioneta4, "A017");
        }

        private void Pict_Camioneta5_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_NCamioneta5, Pict_Camioneta5, "A018");
        }
        //CONVERTIBLES
        private void Btn_Convertibles_MouseEnter(object sender, EventArgs e)
        {
            Letras_Negras(Btn_Convertibles);
        }
        private void Btn_Convertibles_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Convertibles, Btn_Convertibles);
        }
        private void Btn_Convertibles_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Letras_Negras(Btn_Convertibles);
            AlterarBorde();
            Ocultar_PanelesConvertibles();
            Panel_Convertibles.Visible = true;
            Btn_Convertibles.FlatAppearance.BorderSize = 0;
            lbl_Convertibles.Visible = true;

        }
        private void Pict_Convertible1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Convertible1.Visible = true;
        }

        private void Pict_Convertible2_MouseEnter(object sender, EventArgs e)
        {
            lbl_Convertible2.Visible = true;
        }

        private void Pict_Convertible3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Convertible3.Visible = true;
        }

        private void Pict_Convertible1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Convertible1.Visible = false;
        }

        private void Pict_Convertible2_MouseLeave(object sender, EventArgs e)
        {
            lbl_Convertible2.Visible = false;
        }

        private void Pict_Convertible3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Convertible3.Visible = false;
        }
        //MOSTRAR DETALLES DEL CONVERTIBLE

        private void Pict_Convertible1_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Convertible1, Pict_Convertible1, "A015");
        }

        private void Pict_Convertible2_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Convertible2, Pict_Convertible2, "A01");
        }

        private void Pict_Convertible3_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Convertible3, Pict_Convertible3, "A012");
        }
        //DEPORTIVOS
        private void Btn_Deportivos_MouseEnter(object sender, EventArgs e)
        {
            Letras_Negras(Btn_Deportivos);
        }
        private void Btn_Deportivos_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Deportivos, Btn_Deportivos);
        }
        private void Btn_Deportivos_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Letras_Negras(Btn_Deportivos);
            AlterarBorde();
            Ocultar_PanelesDeportivos();
            Panel_Deportivos.Visible = true;
            Btn_Deportivos.FlatAppearance.BorderSize = 0;
            lbl_Deportivos.Visible = true;
        }
        private void Pict_Deportivo1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Deportivo1.Visible = true;
        }

        private void Pict_Deportivo2_MouseEnter(object sender, EventArgs e)
        {
            lbl_Deportivo2.Visible = true;
        }

        private void Pict_Deportivo3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Deportivo3.Visible = true;
        }

        private void Pict_Deportivo1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Deportivo1.Visible = false;
        }

        private void Pict_Deportivo2_MouseLeave(object sender, EventArgs e)
        {
            lbl_Deportivo2.Visible = false;

        }

        private void Pict_Deportivo3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Deportivo3.Visible = false;

        }
        //MOSTRAR DETALLES DE LOS DEPORTIVOS

        private void Pict_Deportivo1_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Deportivo1, Pict_Deportivo1, "A04");
        }

        private void Pict_Deportivo2_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Deportivo2, Pict_Deportivo2, "A05");
        }

        private void Pict_Deportivo3_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Deportivo3, Pict_Deportivo3, "A013");
        }
        //ELECTRICOS
        private void Btn_Electricos_MouseEnter(object sender, EventArgs e)
        {
            Letras_Negras(Btn_Electricos);
        }
        private void Btn_Electricos_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Electricos, Btn_Electricos);
        }
        private void Btn_Electricos_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Letras_Negras(Btn_Electricos);
            AlterarBorde();
            Ocultar_PanelesElectrico();
            Panel_Electricos.Visible = true;
            Btn_Electricos.FlatAppearance.BorderSize = 0;
            lbl_Electricos.Visible = true;
        }
        private void Pict_Electrico1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Electrico1.Visible = true;
        }

        private void Pict_Electrico2_MouseEnter(object sender, EventArgs e)
        {
            lbl_Electrico2.Visible = true;

        }

        private void Pict_Electrico3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Electrico3.Visible = true;
        }

        private void Pict_Electrico4_MouseEnter(object sender, EventArgs e)
        {
            lbl_Electrico4.Visible = true;

        }

        private void Pict_Electrico1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Electrico1.Visible = false;

        }

        private void Pict_Electrico2_MouseLeave(object sender, EventArgs e)
        {
            lbl_Electrico2.Visible = false;

        }

        private void Pict_Electrico3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Electrico3.Visible = false;

        }

        private void Pict_Electrico4_MouseLeave(object sender, EventArgs e)
        {
            lbl_Electrico4.Visible = false;

        }
        //MOSTRAR DETALLES DE LOS ELECTRICOS

        private void Pict_Electrico1_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Electrico1, Pict_Electrico1, "A03");
        }

        private void Pict_Electrico2_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Deportivo2, Pict_Electrico2, "A08");
        }

        private void Pict_Electrico3_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Electrico3, Pict_Electrico3, "A010");
        }

        private void Pict_Electrico4_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Electrico4, Pict_Electrico4, "A011");
        }
        //PERFORMANCE
        private void Btn_Performance_MouseEnter(object sender, EventArgs e)
        {
            Letras_Negras(Btn_Performance);
        }
        private void Btn_Performance_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Performance, Btn_Performance);
        }
        private void Btn_Performance_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Letras_Negras(Btn_Performance);
            AlterarBorde();
            MostrarPanel_Performance();
            Panel_Performance.Visible = true;
            Btn_Performance.FlatAppearance.BorderSize = 0;
            lbl_Performance.Visible = true;
        }
        private void Pict_Performance1_MouseEnter(object sender, EventArgs e)
        {
            lbl_Performance1.Visible = true;
        }

        private void Pict_Performance2_MouseEnter(object sender, EventArgs e)
        {
            lbl_Performance2.Visible = true;
        }

        private void Pict_Performance3_MouseEnter(object sender, EventArgs e)
        {
            lbl_Performance3.Visible = true;
        }

        private void Pict_Performance1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Performance1.Visible = false;
        }

        private void Pict_Performance2_MouseLeave(object sender, EventArgs e)
        {
            lbl_Performance2.Visible = false;

        }

        private void Pict_Performance3_MouseLeave(object sender, EventArgs e)
        {
            lbl_Performance3.Visible = false;

        }
        //MOSTRAR DETALLES DE LOS PERFORMANCE

        private void Pict_Performance1_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Performance1, Pict_Performance1, "A06");
        }

        private void Pict_Performance2_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Performance2, Pict_Performance2, "A07");
        }

        private void Pict_Performance3_Click(object sender, EventArgs e)
        {
            Vehiculo_Detalles(lbl_Performance3, Pict_Performance3, "A014");
        }
        //INICIAR SESION DESDE FORM AUTOS

        private void Btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            Inciar_Sesion();
            this.Close();
        }
        //FIN DISEÑO
        //INICIO DE LOGICA
        public void PasarUsuario(string n_identificacion)
        {
            Cliente cliente = new Cliente();
            ActivarLabelCliente();
            foreach (Cliente cl in Sl.Buscar_Cliente(n_identificacion))
            {
                lbl_ID.Text = cl.N_Identificacion.ToString();
                lbl_Nombre.Text = cl.Nombre_Completo;
                lbl_DineroDisp.Text = cl.Presupuesto.ToString();
                lbl_Id_Cliente.Text = cl.Id_Cliente;
            }
        }

        public void ActivarLabelCliente()
        {
            Btn_IniciarSesion.Visible = false;
            lbl_Nombre.Visible = true;
            lbl_ID.Visible = true;
            lbl_DineroDisp.Visible = true;
            label11.Visible = true;
        }

        public void ActivarLabelGerente()
        {
            Btn_IniciarSesion.Visible = false;
            lbl_Nombre.Visible = true;
            lbl_Nombre.Text = "Gerente";
            label13.Visible = true; //Label del simbolo $
            label11.Visible = true; //Label del Saldo Disponible
            lbl_DineroDisp.Visible = true;
            lbl_ID.Visible = false;
            label45.Visible = false;
            lbl_DineroDisp.Text = Sf.Contar_DineroTotal().ToString();
        }

        private void Btn_Comprar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            if (lbl_Nombre.Text == "Perfil Sesion")
            {
                if (Sa.MensajeInciciarSesion(login) == true)
                {
                    this.Close();
                }
            }
            else if (lbl_Nombre.Text == "Gerente")
            {
                foreach (var item in Sa.GetAll())
                {
                    if (item.Id_Auto.Equals(lbl_Id_Auto.Text))
                    {
                        inventario.Fecha_Compra = DateTime.Now;
                        inventario.Matricula = Sa.Generar_Matricula();
                        inventario.Nombre_Auto = item.Nombre_Auto;
                        inventario.Precio_Venta = item.Precio_Venta;
                        inventario.Modelo = item.Modelo;
                        inventario.Categoria = item.Categoria;
                        inventario.Motor = item.Motor;
                        inventario.Potencia = item.Potencia;
                        inventario.Valvulas = item.Valvulas;
                        inventario.Asientos = item.Asientos;
                        inventario.Sistema_Combustible = item.Sistema_Combustible;
                        inventario.Tipo_Transmision = item.Tipo_Transmision;
                        inventario.Id_Auto = lbl_Id_Auto.Text;
                        finanzas.Nombre_Auto = item.Nombre_Auto;
                    }
                }
                finanzas.Tipo = "Compra de Auto";
                finanzas.Fecha_Ingreso = DateTime.Now;
                finanzas.Monto_Ingreso = 0;
                finanzas.Fecha_Gasto = DateTime.Now;
                finanzas.Monto_Gasto = int.Parse(lbl_Precio.Text);
                finanzas.Monto_Total = 1 * -int.Parse(lbl_Precio.Text);               
                Si.Insertar(inventario);
                Sf.Insertar(finanzas);
                lbl_DineroDisp.Text = Sf.Contar_DineroTotal().ToString();
                MessageBox.Show("Compra Realizada Satisfactoriamente.");
            }
            else
            {
                if (Sa.Mensaje_Comprar() == true)
                {
                    if (Sa.Comprobar_Saldo(int.Parse(lbl_DineroDisp.Text),int.Parse(lbl_Precio.Text))== true)
                    {
                        bool Encontro = false;

                        if (Se.GetAll() != null)
                        {
                            foreach (var item in Si.GetAll())
                            {
                                if (item.Id_Auto.Equals(lbl_Id_Auto.Text))
                                {
                                    ventas.Nombre_Vendedor = Se.Obtener_Empleado();
                                    if(ventas.Nombre_Vendedor != "Sin Vendedor Disponible")
                                    {
                                        ventas.Id_Cliente = lbl_Id_Cliente.Text;
                                        ventas.Comprador = lbl_Nombre.Text;
                                        ventas.Fecha_Vendido = DateTime.Now;
                                        ventas.Precio_Venta = item.Precio_Venta;
                                        ventas.Id_Auto = item.Id_Auto;
                                        ventas.Matricula = item.Matricula;
                                        ventas.Nombre_Auto = item.Nombre_Auto;
                                        ventas.Categoria = item.Categoria;
                                        ventas.Motor = item.Motor;
                                        ventas.Potencia = item.Potencia;
                                        ventas.Sistema_Combustible = item.Sistema_Combustible;
                                        ventas.Tipo_Transmision = item.Tipo_Transmision;
                                        finanzas.Nombre_Auto = item.Nombre_Auto;
                                        finanzas.Tipo = "Venta de Auto";
                                        finanzas.Fecha_Ingreso = DateTime.Now;
                                        finanzas.Monto_Ingreso = int.Parse(lbl_Precio.Text); 
                                        finanzas.Fecha_Gasto = DateTime.Now;
                                        finanzas.Monto_Gasto = 0;
                                        finanzas.Monto_Total = int.Parse(lbl_Precio.Text);
                                        cliente.Presupuesto = int.Parse(lbl_DineroDisp.Text) - int.Parse(lbl_Precio.Text);
                                        cliente.Autos_Comprados += 1;
                                        lbl_DineroDisp.Text = cliente.Presupuesto.ToString();
                                        Se.Añadir_Comision(ventas.Nombre_Vendedor,int.Parse(lbl_Precio.Text));
                                        Sl.UpdateAuto(lbl_Id_Cliente.Text, cliente);
                                        Sv.Insertar(ventas);
                                        Si.Delete(item);
                                        Sf.Insertar(finanzas);
                                        Sa.Proceso_Compra(Panel_ProcesoC,Lbl_Empleado,Lbl_Punto1,Lbl_Punto2,Lbl_Punto3,Pict_Logo, Llb_CompraCmpt, Pict_CompraCmpt, Btn_Cerrar,ventas.Nombre_Vendedor);                                      
                                        Encontro = true;
                                        break;
                                    }
                                    else
                                    {
                                        Encontro = true;
                                        break;
                                    }
                                    
                                }                                             
                            }                           
                        }
                        if (Encontro == false)
                        {
                            MessageBox.Show("No hay autos de este tipo disponibles por el momento.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la compra, Dinero insuficiente");
                    }
                }

            }


        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Panel_ProcesoC.Visible = false;
        }
    }
}
    

