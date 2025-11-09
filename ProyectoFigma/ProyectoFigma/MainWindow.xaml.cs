using Microsoft.Win32;
using System;
using System.Windows;

namespace ProyectoFigma
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // usa el generado por WPF, no lo redefinas
            DatabaseHelper.Inicializar();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Password.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DatabaseHelper.ValidarUsuario(usuario, contraseña))
            {
                Principal principal = new Principal();
                principal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
        }
    }
}

