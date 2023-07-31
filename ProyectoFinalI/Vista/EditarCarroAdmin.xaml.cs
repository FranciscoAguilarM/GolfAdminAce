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
    /// Lógica de interacción para EditarCarroAdmin.xaml
    /// </summary>
    public partial class EditarCarroAdmin : Window
    {
        public EditarCarroAdmin(Carro requests)
        {
            this.InitializeComponent();
            x = requests.PkMatricula;
            Modelo.Text = requests.Modelo;
            Color.Text = requests.Color;
            Observaciones.Text = requests.Observaciones;
        }
        Carro carro = new Carro();
        ServicioCarro service = new ServicioCarro();
        private int x;

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            VistaAdmin view1 = new VistaAdmin();
            view1.Show();
            Close();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (Modelo.Text == "" || Color.Text == "" || Observaciones.Text == "")
            {
                Error.Content = "Todos los campos deben estar llenos";
            }
            else
            {
                carro.PkMatricula = x;
                carro.Modelo = Modelo.Text;
                carro.Color = Color.Text;
                carro.Observaciones = Observaciones.Text;
                service.EditarCarrito(carro);
                Error.Content = "Se Han Modificado Los Datos ";

            }
        }
    }
}
