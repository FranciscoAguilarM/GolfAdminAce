using ProyectoFinalI.Entities;
using ProyectoFinalI.Services;
using ProyectoFinalI.Vista;
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

namespace ProyectoFinalI
{
    /// <summary>
    /// Lógica de interacción para EditarEmpleadoAdmin.xaml
    /// </summary>
    public partial class EditarEmpleadoAdmin : Window
    {
        public EditarEmpleadoAdmin(Empleado requests)
        {
            this.InitializeComponent();
            GetRoles();
            x = requests.PkEmpleado;
            Nombre.Text = requests.Nombre;
            Apellido.Text = requests.Apellido;
            Usuario.Text = requests.Usuario;
            Contrasena.Text = requests.Contrasena;
            SelectRol.Text = Convert.ToString(requests.FKRol);
        }
        Empleado empleado = new Empleado();
        ServicioEmpleado service = new ServicioEmpleado();
       ServicioEmpleado servicio = new ServicioEmpleado(); 
        private int x;

   
        public void GetRoles()
        {
            SelectRol.ItemsSource = service.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValue = "PkRol";
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            VistaAdmin   view1 = new VistaAdmin();
            view1.Show();
            Close();
        }


        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (Nombre.Text == "" || Apellido.Text == "" || Usuario.Text == "" || Contrasena.Text == "" || SelectRol.Text == "")
            {
                Error.Content = "No Puedes Dejar Campos Vacios";
            }
            else
            {
                empleado.PkEmpleado = x;
                empleado.Nombre = Nombre.Text;
                empleado.Apellido = Apellido.Text;
                empleado.Usuario = Usuario.Text;
                empleado.Contrasena = Contrasena.Text;
                // es Convert.ToInt32(SelectRol.SelectedItem()); 
                if(SelectRol.Text == "Admin")
                {
                    empleado.FKRol = 1;
                }
                else if(SelectRol.Text =="Empleado")
                {
                    empleado.FKRol = 2;
                }
                //service.AgregarEmpleado(empleado);
                servicio.EditarEmpleado(empleado);
                Nombre.Clear();
                Apellido.Clear();
                Usuario.Clear();
                Contrasena.Clear();

                Error.Content="Se agrego correctamente";
                //ActualizarTabla();
            }
          
        }

        private void SelectRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


    

    
}

