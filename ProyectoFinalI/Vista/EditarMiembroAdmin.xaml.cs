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
    /// Lógica de interacción para EditarMiembroAdmin.xaml
    /// </summary>
    public partial class EditarMiembroAdmin : Window
    {
        public EditarMiembroAdmin(Miembro requests)
        {
            this.InitializeComponent();
            x = requests.PkMiembro;
            TxtNombre.Text = requests.Nombre;
            TxtApellido.Text = requests.Apellido;
        }
        Miembro miembro = new Miembro();
        ServicioMiembro service = new ServicioMiembro();
        private int x;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombre.Text == "" || TxtApellido.Text == "")
            {
                Error.Content = "No Puedes Dejar Campos Vacios ";
            }
            else
            {
                miembro.PkMiembro = x;
                miembro.Nombre = TxtNombre.Text;
                miembro.Apellido = TxtApellido.Text;
                service.EditarMiembro(miembro);
                Error.Content = "Se Han Modificado Los Datos ";

            }

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            VistaAdmin view1 = new VistaAdmin();
            view1.Show();
            Close();
        }
    }
}
