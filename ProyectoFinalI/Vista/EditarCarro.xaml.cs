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
    /// Lógica de interacción para EditarCarro.xaml
    /// </summary>
    public partial class EditarCarro : Window
    {
        public EditarCarro(Carro requests)
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
            VentanaEmpleado view1 = new VentanaEmpleado();
            view1.Show();
            Close();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (Modelo.Text == "" || Color.Text == ""|| Observaciones.Text== "")
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
