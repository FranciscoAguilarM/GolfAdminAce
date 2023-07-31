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
    /// Lógica de interacción para EditarServiceAdmin.xaml
    /// </summary>
    public partial class EditarServiceAdmin : Window
    {

  
          public EditarServiceAdmin(Asignar requests)
          {
              this.InitializeComponent();
              x = requests.IdAsig;
              Matricula.Text = requests.MatriculaCarrito;
              Nombmiem.Text = requests.NombreMiembro;
              NombreEmp.Text = requests.nombreEmpleado;
          }
          Asignar asignar = new Asignar();
          ServicioAsignar service = new ServicioAsignar();
          private int x;

          private void BtnEditar_Click(object sender, RoutedEventArgs e)
          {
                         if (Matricula.Text == "" || Nombmiem.Text == "" || NombreEmp.Text == "")
              {
                  Error.Content = "Todos los campos deben estar llenos";
              }
              else
              {
                  asignar.IdAsig = x;
                  asignar.MatriculaCarrito = Matricula.Text;
                  asignar.NombreMiembro = Nombmiem.Text;
                  asignar.nombreEmpleado = NombreEmp.Text;
                  service.EditarAsig(asignar);
                  Error.Content = "Los datos se modificarón";
              }

          }


          private void BtnCerrar_Click(object sender, RoutedEventArgs e)
          {
              VistaAdmin vw2 = new VistaAdmin();
              vw2.Show();
              Close();
          }
    }
}
