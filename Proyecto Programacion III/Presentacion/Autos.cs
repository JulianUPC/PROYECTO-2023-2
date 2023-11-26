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
        Manejo_Formulario Mf = new Manejo_Formulario();
        ServicioClientes Sl = new ServicioClientes(configConnnection.ConnectionString);
        Servicio_Inventario Si = new Servicio_Inventario(configConnnection.ConnectionString);
        ServicioAutos Sa = new ServicioAutos(configConnnection.ConnectionString);
        Servicio_Finanzas Sf = new Servicio_Finanzas(configConnnection.ConnectionString);
        Servicio_Ventas Sv = new Servicio_Ventas(configConnnection.ConnectionString);
        Servicio_Empleado Se = new Servicio_Empleado(configConnnection.ConnectionString);
        Inventario inventario = new Inventario();
        Finanzas finanzas = new Finanzas();
        Ventas ventas = new Ventas();
        Cliente cliente = new Cliente();

        public Autos()
        {
            InitializeComponent();
            Actualizar_Lista();   //Actualiza las listas al iniciar el formulario
        }
        //Cerrar el formulario
        public void Cerrar_Fomulario()
        {
            this.Close(); 
        }
        //Boton Volver
        private void Btn_Volver_Click(object sender, EventArgs e)
        {
            Presentacion.Menu menu = new Presentacion.Menu();
            Gerencia gerencia = new Gerencia();
            //Si al darle aceptar al mensaje de salir devolvera true por lo tanto este formulario se cerrara
            if (Mf.Abrir_Form(Panel_Detalles, lbl_Nombre, lbl_DineroDisp, menu, gerencia) == true) 
            {
                this.Close();
            }
                 
        }
        //Codigo para el diseño del catalogo de autos
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
            Mf.Letras_Grises(Btn_Camionetas);
            Mf.Letras_Grises(Btn_Convertibles);
            Mf.Letras_Grises(Btn_Deportivos);
            Mf.Letras_Grises(Btn_Electricos);
            Mf.Letras_Grises(Btn_Performance);
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
                Mf.Letras_Grises(boton);
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
            //Actualiza el nombre,precio y imagen del vehiculo si es que este fue cambiado en la base de datos
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
        //Actualiza el el precio de los vehiculos si es que esta en modo gerente o en modo cliente
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

        //Muestra los detalles del vehiculo seleccionado
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
        //Abre el Form Iniciar Sesion si es que este es invocado en un metodo
        public void Inciar_Sesion()
        {
            Login login = new Login();
            login.Show();
        }
        //CODIGO NECESARIO PARA EL COMPORTAMIENTO DEL BOTON AL PASAR EL MOUSE POR ESTE
        //CAMIONETAS
        private void Btn_Camionetas_MouseEnter(object sender, EventArgs e)
        {
            Mf.Letras_Negras(Btn_Camionetas);  //ENTRADA DE MOUSE EN EL BOTON
        }
        private void Btn_Camionetas_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Camionetas, Btn_Camionetas); //SALIDA DEL MOUSE EN EL BOTON
        }
        private void Btn_Camionetas_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Mf.Letras_Negras(Btn_Camionetas);
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
            Mf.Letras_Negras(Btn_Convertibles);
        }
        private void Btn_Convertibles_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Convertibles, Btn_Convertibles);
        }
        private void Btn_Convertibles_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Mf.Letras_Negras(Btn_Convertibles);
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
            Mf.Letras_Negras(Btn_Deportivos);
        }
        private void Btn_Deportivos_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Deportivos, Btn_Deportivos);
        }
        private void Btn_Deportivos_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Mf.Letras_Negras(Btn_Deportivos);
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
            Mf.Letras_Negras(Btn_Electricos);
        }
        private void Btn_Electricos_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Electricos, Btn_Electricos);
        }
        private void Btn_Electricos_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Mf.Letras_Negras(Btn_Electricos);
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
            Mf.Letras_Negras(Btn_Performance);
        }
        private void Btn_Performance_MouseLeave(object sender, EventArgs e)
        {
            Comprobrar_Label(lbl_Performance, Btn_Performance);
        }
        private void Btn_Performance_Click(object sender, EventArgs e)
        {
            Desactivar_Labels();
            BotonesGrises();
            Mf.Letras_Negras(Btn_Performance);
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
        //Agarra el nombre del cliente que inicio sesion y lo traslada a este formulario
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

        public void ActivarLabelCliente() //Se activa por si el que inicio sesion fue un cliente
        {
            Btn_IniciarSesion.Visible = false;
            lbl_Nombre.Visible = true;
            lbl_ID.Visible = true;
            lbl_DineroDisp.Visible = true;
            label11.Visible = true;
        }

        public void ActivarLabelGerente() //Se activa por si el que inicio sesion fue el gerente
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
                //Si se le da al boton comprar y no se ha iniciado sesion se abrira el formulario de iniciar sesion si es que este acepta hacerlo
                if (Sa.MensajeInciciarSesion(login) == true)
                {
                    this.Close();
                }
            }
            else if (lbl_Nombre.Text == "Gerente") //De lo contrario si fue el gerente se comprara el auto al darle click
            {
                Insertar_DatosGerente();
            }
            else
            {
                Comprobar_DatosCliente(); //Si es el cliente se comprobara los datos necesarios para comprar el auto
            }


        }
        public void Comprobar_DatosCliente()
        {
            if (Sa.Mensaje_Comprar() == true) //Saldra un mensaje de si desea comprar el auto, si lo hace pasara a comprubar el saldo
            {
                if (Sa.Comprobar_Saldo(int.Parse(lbl_DineroDisp.Text), int.Parse(lbl_Precio.Text)) == true) //Comprueba si tiene salda disponible
                {
                    if (Se.GetAll() != null) //Comprueba si hay vendedores disponibles
                    {
                        Insertar_DatosCliente();
                    }                  
                }
                else
                {
                    MessageBox.Show("No se pudo completar la compra, Dinero insuficiente");
                }
            }
        }
        public void Insertar_DatosCliente()
        {
            foreach (var item in Si.GetAll()) //Busca el auto que se desea comprar
            {
                if (item.Id_Auto.Equals(lbl_Id_Auto.Text)) //Si lo encuentra procede a verificar si hay empleados disponibles
                {
                    ventas.Nombre_Vendedor = Se.Obtener_Empleado();
                    if (ventas.Nombre_Vendedor != "Sin Vendedor Disponible") //Si hay vendedores disponibles se procede a insertar los datos
                    {
                        ventas.Id_Cliente = lbl_Id_Cliente.Text;
                        ventas.Comprador = lbl_Nombre.Text;
                        ventas.Fecha_Vendido = DateTime.Now;
                        ventas.Precio_Venta = item.Precio_Venta; 
                        ventas.Id_Auto = item.Id_Auto;
                        ventas.Matricula = item.Matricula;
                        ventas.Nombre_Auto = item.Nombre_Auto; //Datos de Ventas necesario para insertar a la bse de datos
                        ventas.Categoria = item.Categoria;
                        ventas.Motor = item.Motor;
                        ventas.Potencia = item.Potencia;
                        ventas.Sistema_Combustible = item.Sistema_Combustible;
                        ventas.Tipo_Transmision = item.Tipo_Transmision;
                        finanzas.Nombre_Auto = item.Nombre_Auto; 
                        finanzas.Tipo = "Venta de Auto"; //Como es una venta de auto seria un ingreso
                        finanzas.Fecha_Ingreso = DateTime.Now;
                        finanzas.Monto_Ingreso = int.Parse(lbl_Precio.Text); //Datos de Finanzas necesario para insertar a la bse de datos
                        finanzas.Fecha_Gasto = DateTime.Now;
                        finanzas.Monto_Gasto = 0;
                        finanzas.Monto_Total = int.Parse(lbl_Precio.Text);
                        cliente.Presupuesto = int.Parse(lbl_DineroDisp.Text) - int.Parse(lbl_Precio.Text); //Datos de Cliente que se actualizaran en la base de datos
                        cliente.Autos_Comprados += 1;
                        lbl_DineroDisp.Text = cliente.Presupuesto.ToString();
                        Se.Añadir_Comision(ventas.Nombre_Vendedor, int.Parse(lbl_Precio.Text));
                        Sl.UpdateAuto(lbl_Id_Cliente.Text, cliente); //Se actualizan los datos del cliente en la base de datos
                        Sv.Insertar(ventas); //Se insertan los datos en la base de datos
                        Si.Delete(item); //Se elimina el auto de la base de datos
                        Sf.Insertar(finanzas);
                        Sa.Proceso_Compra(Panel_ProcesoC, Lbl_Empleado, Lbl_Punto1, Lbl_Punto2, Lbl_Punto3, Pict_Logo, Llb_CompraCmpt, Pict_CompraCmpt, Btn_Cerrar, ventas.Nombre_Vendedor);
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    MessageBox.Show("No hay autos de este tipo disponibles por el momento.");
                }
            }
        }
        public void Insertar_DatosGerente() //Inserta los datos del gerente en la base de datos
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
                    inventario.Potencia = item.Potencia; //Datos de Inventario necesario para insertar a la bse de datos
                    inventario.Valvulas = item.Valvulas;
                    inventario.Asientos = item.Asientos;
                    inventario.Sistema_Combustible = item.Sistema_Combustible;
                    inventario.Tipo_Transmision = item.Tipo_Transmision;
                    inventario.Id_Auto = lbl_Id_Auto.Text;
                    finanzas.Nombre_Auto = item.Nombre_Auto; //Agarra el nombre del auto para saber cual auto fue vendido
                }
            }
            finanzas.Tipo = "Compra de Auto"; //Como es una compra de auto seria un gasto
            finanzas.Fecha_Ingreso = DateTime.Now;
            finanzas.Monto_Ingreso = 0;
            finanzas.Fecha_Gasto = DateTime.Now;  
            finanzas.Monto_Gasto = int.Parse(lbl_Precio.Text);
            finanzas.Monto_Total = 1 * -int.Parse(lbl_Precio.Text); //Se Convierte el mmonto total en negativo para que se pueda restar en la base de datos
            Si.Insertar(inventario);
            Sf.Insertar(finanzas);
            lbl_DineroDisp.Text = Sf.Contar_DineroTotal().ToString();
            MessageBox.Show("Compra Realizada Satisfactoriamente.");
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Panel_ProcesoC.Visible = false;
        }
    }
}
    

