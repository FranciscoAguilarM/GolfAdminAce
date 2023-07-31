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
    /// Lógica de interacción para VentanaEmpleado.xaml
    /// </summary>
    public partial class VentanaEmpleado : Window
    {
        public VentanaEmpleado()
        {
            this.InitializeComponent();
            ActualizarTabla();
        }
        ServicioCarro service = new ServicioCarro();
        Carro carrito = new Carro();

      ServicioMiembro servicio2 = new ServicioMiembro();    
        Miembro miembro = new ();

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
        }
        private void BtnAgregar3_Click(object sender, RoutedEventArgs e)
        {
            //Miembro
            if (TxtNombre.Text == "" || TxtApellido.Text == "")
            {
                Error2.Content = "Todos los campos deben estar llenos";
            }
            else
            {
                miembro.Nombre = TxtNombre.Text;
                miembro.Apellido = TxtApellido.Text;

                var validacion = servicio2.ValidarAgregarMiembro(miembro);
                if (validacion != "1")
                {
                    servicio2.AgregarMiembro(miembro);
                    Error2.Content =  "Datos Agregados";
                    TxtNombre.Clear();
                    TxtApellido.Clear();
                    ActualizarTabla();
                }
                else
                {
                    Error2.Content = "Este Miembro Ya Existe";
                }
            }
        }

        private void BtnAgregar2_Click(object sender, RoutedEventArgs e)
        {
            //Carrito
            if (Modelo.Text == "" || Color.Text == "" || Observaciones.Text == "")
            {
                Error3.Content = "Todos los campos deben estar llenos";
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
                    Error3.Content = "Datos Agregados";
                    Modelo.Clear();
                    Color.Clear();
                    Observaciones.Clear();
                    ActualizarTabla();
                }
                else
                {
                    Error3.Content = "Este Carrito Ya Existe";
                }
            }
        }

        private void BtnAgregar1_Click(object sender, RoutedEventArgs e)
        {
            // asig
            if (ModeloA.Text == "" || NomM.Text == "" || NomEmp.Text == "")
            {
                Error.Content = "Todos los campos deben estar llenos";
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
                    Error.Content = "Datos Agregados";
                    ModeloA.Clear();
                    NomM.Clear();
                    NomEmp.Clear();
                    
                    ActualizarTabla();
                }
                else
                {
                    Error.Content = "Este Carrito Ya Existe";
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Miembro miembro = new Miembro();
            var button = (Button)sender;
            var miembros = (Miembro)button.DataContext;
            Editarmiembro view3 = new Editarmiembro(miembros);
            view3.Show();
            Close();
            ActualizarTabla();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var carrito = (Carro)button.DataContext;
            EditarCarro view4 = new(carrito);
            view4.Show();
            Close();
            ActualizarTabla();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var servicio = (Asignar)button.DataContext;
           
            EditarServicio view5 =new EditarServicio(servicio);
            view5.Show();
            Close();
            ActualizarTabla();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IniciarSecion view6 = new IniciarSecion();
            view6.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IniciarSecion view6 = new IniciarSecion();
            view6.Show();
            Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            IniciarSecion view6 = new IniciarSecion();
            view6.Show();
            Close();
        }
    }

}
