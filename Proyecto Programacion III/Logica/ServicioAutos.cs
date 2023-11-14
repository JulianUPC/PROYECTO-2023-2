using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica2
{
    public class ServicioAutos : ICrud<Auto>
    {

        Datos.RepositorioAuto repositorioAutos;
        Datos.RepositorioInventario repositorioInventario;
        Datos.repositorioFinanzas repositorioFinanzas;
        Inventario inventario = new Inventario();
        Finanzas finanzas = new Finanzas();
        Auto auto;
        Autos_de_Clientes autos_De_Clientes;
        public ServicioAutos(string conexion)
        {
            repositorioAutos = new RepositorioAuto(conexion);
        }
        public void ObtenerIdentificacion(string usuario)
        {

        }
        public void Insertar(Auto Entidad)
        {
            
        }
        public void Update(string id,Auto Entidad)
        {

        }
        public void Delete(Auto Entidad)
        {

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

        public string Generar_Matricula()
        {
            for (int i = 0; i < 10; i++)
            {
                Random randomChar = new Random();
                char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                string matriculaRandom = randomChar.Next(10, 99) + "-" + letras[randomChar.Next(26)].ToString() + letras[randomChar.Next(26)].ToString() + "-" + randomChar.Next(10, 99);

                return matriculaRandom;
            }

            return Generar_Matricula().ToString();
        }
        public void Comprar_Auto(string modo_gerente,string id_auto,int precio,int saldo)
        {            
            if (modo_gerente == "Gerente")
            {
                foreach(var item in repositorioAutos.GetAll())
                {
                    inventario.Fecha_Compra = DateTime.Now;
                    inventario.Matricula = Generar_Matricula();
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
                    inventario.Id_Auto = item.Id_Auto;   
                    finanzas.Nombre_Auto = item.Nombre_Auto;
                }
                finanzas.Tipo = "Compra de Auto";
                finanzas.Monto_Total = saldo - precio;
                finanzas.Fecha_Gasto = DateTime.Now;
                finanzas.Monto_Gasto = precio;
                repositorioInventario.Insert(inventario);
                repositorioFinanzas.Insert(finanzas);
                
            }
            else
            {

            }
        }
        public bool Modo_Gerente(bool permiso)
        {
            bool Acceso;
            Acceso = permiso;
            return Acceso;
        }
        public List<Auto> GetAll()
        {
            return repositorioAutos.GetAll();
        }
    }
}
