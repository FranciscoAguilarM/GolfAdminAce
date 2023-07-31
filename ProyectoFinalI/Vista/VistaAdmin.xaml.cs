using ProyectoFinalI.Entities;
using ProyectoFinalI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinalI.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaAdmin.xaml
    /// </summary>
    public partial class VistaAdmin : Window
    {
        public VistaAdmin()
        {
            this.InitializeComponent();
            ActualizarTabla();
        }
        ServicioCarro service = new ServicioCarro();
        Carro carrito = new Carro();

        ServicioEmpleado servicio4 = new ServicioEmpleado();
        Empleado empleado = new Empleado();

        ServicioMiembro servicio2 = new ServicioMiembro();
        Miembro miembro = new();

        ServicioAsignar servicio3 = new ServicioAsignar();
        Asignar asignar = new();
        public void ActualizarTabla()
        {
           var solicitudes2 = service.VerCarrito();
            DataGridUserTable2.ItemsSource = solicitudes2;

            var solicitudes1 = servicio2.VerMiembro();
            DataGridUserTable1.ItemsSource = solicitudes1;

            var solicitudes3 = servicio3.VerAsignar();
            DataGridUserTable3.ItemsSource = solicitudes3;

            var solicitudes4 = servicio4.VerEmpleado();
            DataGridUserTable4.ItemsSource = solicitudes4;
        }
        private void BtnAgregar3_Click(object sender, RoutedEventArgs e)
        {
            //miembr
            if (TxtNombre.Text == "" || TxtApellido.Text == "")
            {
            }
            else
            {
                miembro.Nombre = TxtNombre.Text;
                miembro.Apellido = TxtApellido.Text;

                var validacion = servicio2.ValidarAgregarMiembro(miembro);
                if (validacion != "1")
                {
                    servicio2.AgregarMiembro(miembro);
                    Errormi.Content =  "Datos Agregados";
                    TxtNombre.Clear();
                    TxtApellido.Clear();
                    ActualizarTabla();
                }
                else
                {
                    Errormi.Content = "Este Miembro Ya Existe";
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var miembro = (Miembro)button.DataContext;
            servicio2.EliminarMiembro(miembro);
            ActualizarTabla();
            Errormi.Content = "Los Datos Se Han Eliminado";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Miembro miembro = new Miembro();
            var button = (Button)sender;
            var miembros = (Miembro)button.DataContext;
            EditarMiembroAdmin view3 = new EditarMiembroAdmin(miembros);
            view3.Show();
            Close();
            ActualizarTabla();

        }
        private void BtnAgregar2_Click(object sender, RoutedEventArgs e)
        {
            //carrito
            if (Modelo.Text == "" || Color.Text == "" || Observaciones.Text == "")
            {
                Errorcar.Content = "Llena Todos Los Campos Necesarios...";
            }
            else
            {
                carrito.Modelo = Modelo.Text;
                carrito.Color = Color.Text;
                carrito.Observaciones = Observaciones.Text;

                var validacion = service.ValidarAgregarCarrito(carrito);
                if (validacion != "1")
                {
                    service.AgregarCarrito(carrito);
                    Errorcar.Content ="Datos Agregados";
                    Modelo.Clear();
                    Color.Clear();
                    Observaciones.Clear();
                    ActualizarTabla();
                }
                else
                {
                    Errorcar.Content ="Este Carrito Ya Existe";
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var carrito = (Carro)button.DataContext;
            EditarCarroAdmin view4 = new(carrito);
            view4.Show();
            Close();
            ActualizarTabla();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var carrito = (Carro)button.DataContext;
            service.EliminarCarrito(carrito);
            ActualizarTabla();
            Errorcar.Content = "Los Datos Se Han Eliminado";
        }
   
   

        private void BtnAgregar4_Click(object sender, RoutedEventArgs e)
        {
            if (TNombre.Text == "" || TApellido.Text == "" || TUsuario.Text == "" || TContraseña.Text == "")
            {
                Error.Content = "Llena Todos Los Campos Necesarios...";
            }
            else
            {
                empleado.Nombre = TNombre.Text;
                empleado.Apellido = TApellido.Text;
                empleado.Usuario = TUsuario.Text;
                empleado.Contrasena = TContraseña.Text;
               // empleado

             


                var validacion = servicio4.ValidarAgregarEmpleado(empleado);
                if (validacion != "1")
                {
                    servicio4.AgregarEmpleado(empleado);
                    Error.Content = "Datos Agregados";
                    TNombre.Clear();
                    TApellido.Clear();
                    TUsuario.Clear();
                    TContraseña.Clear();
                    ActualizarTabla();
                   
                }
                else
                {
                    Error.Content = "Este Usuario Ya Existe";
                }
            }
        }

      

    
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var empleado = (Empleado)button.DataContext;

         EditarEmpleadoAdmin view6 = new EditarEmpleadoAdmin(empleado);
           view6.Show();
            Close();
            ActualizarTabla();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var empleado = (Empleado)button.DataContext;
            servicio4.EliminarEmpleado(empleado);
            ActualizarTabla();
            Error.Content = "Los Datos Se Han Eliminado";

        }
        private void BtnAgregar1_Click(object sender, RoutedEventArgs e)
        {
            //asig
            if (ModeloA.Text == "" || NomM.Text == "" || NomEmp.Text == "")
            {
                Errorasi.Content ="Llena Todos Los Campos Necesarios...";
            }
            else
            {
                asignar.MatriculaCarrito = ModeloA.Text;
                asignar.NombreMiembro = NomM.Text;
                asignar.nombreEmpleado = NomEmp.Text;

                var validacion = service.ValidarAgregarCarrito(carrito);
                if (validacion != "1")
                {
                    servicio3.AgregarAsignar(asignar);
                     Errorasi.Content = "Datos Agregados";
                    ModeloA.Clear();
                    NomM.Clear();
                    NomEmp.Clear();

                    ActualizarTabla();
                }
                else
                {
                    Errorasi.Content =  "Esta Asignacion Ya Existe";
                }
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var servicio = (Asignar)button.DataContext;

            EditarServiceAdmin view5 = new EditarServiceAdmin(servicio);
            view5.Show();
            Close();
            ActualizarTabla();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var asignar = (Asignar)button.DataContext;
            servicio3.EliminarAsig(asignar);
            ActualizarTabla();
            Errorasi.Content =  "Los Datos Se Han Eliminado ";

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            IniciarSecion view6 = new IniciarSecion();
            view6.Show();
            Close();
        }
    }
}
