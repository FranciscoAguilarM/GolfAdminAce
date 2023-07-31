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
    /// Lógica de interacción para IniciarSecion.xaml
    /// </summary>
    public partial class IniciarSecion : Window
    {
        public IniciarSecion()
        {
            InitializeComponent();
        }

        ServicioEmpleado services1 = new ServicioEmpleado();
        Empleado empl = new Empleado();

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            string user = Usuario_.Text;
            string password = Contraseña.Password;
         

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                Usuario_.Clear();
                Contraseña.Clear();
                Error.Content = "Todos los campos deben estar llenos.";
            }
            else
            {
                var response = services1.Login(user, password);

                if (response == null)
                {
                    Error.Content = "Credenciales inválidas. Inténtalo de nuevo.";
                }
                else
                {
                    if (response.Roles.Nombre == "Admin")
                    {
                        VistaAdmin va = new VistaAdmin();
                        Close();
                        va.Show();
                    }
                    else if (response.Roles.Nombre == "Empleado")
                    {
                        VentanaEmpleado ve = new VentanaEmpleado();
                        Close();
                        ve.Show();
                    }
                    else
                    {
                        Error.Content = "Rol desconocido. No tienes permisos para acceder.";
                    }
                }
            }
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            AgregarEmpleado view3 = new AgregarEmpleado();
            view3.Show();
            Close();
        }
    }
        
    
}

