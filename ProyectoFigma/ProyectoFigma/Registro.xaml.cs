using System.Windows;

namespace ProyectoFigma
{
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Password.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (DatabaseHelper.RegistrarUsuario(usuario, contraseña))
            {
                MessageBox.Show("Usuario registrado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario ya existe o hubo un error.");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
