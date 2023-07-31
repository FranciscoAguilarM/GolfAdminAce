using ProyectoFinalI.Entities;
using ProyectoFinalI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinalI.Vista
{
    /// <summary>
    /// Lógica de interacción para AgregarEmpleado.xaml
    /// </summary>
    public partial class AgregarEmpleado : Window
    {
        public AgregarEmpleado()
        {
            this.InitializeComponent();
          
            //ActualizarTabla();
        }
        ServicioEmpleado services = new ();
        Empleado empleado = new();
     
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (Nombre.Text == "" || Apellido.Text == "" || Usuario.Text == "" || Contrasena.Text == "")
            {
                Error.Content = "Todos los campos deben estar llenos";
            }
            else
            {
               // empleado.PkEmpleado = x;
                empleado.Nombre = Nombre.Text;
                empleado.Apellido = Apellido.Text;
                empleado.Usuario = Usuario.Text;
                empleado.Contrasena = Contrasena.Text;
                empleado.FKRol=2;
                    
               
                var validacion = services.ValidarAgregarEmpleado(empleado);
                if (validacion != "1")
                {
                    services.AgregarEmpleado(empleado);
                    Error.Content = "Se Han Agregado los Datos Correctamente ";
                    Nombre.Clear();
                    Apellido.Clear();
                    Usuario.Clear();
                    Contrasena.Clear();
                    
   
                }
                else
                {
                    Error.Content = "Este Miembro Ya Existe";
                }
            }
        }
             
       

 
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            IniciarSecion view1 = new IniciarSecion();
        view1.Show();
        Close();

        }
    }
}
