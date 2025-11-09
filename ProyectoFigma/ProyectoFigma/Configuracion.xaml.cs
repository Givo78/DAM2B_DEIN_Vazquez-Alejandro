using System.Windows;

namespace ProyectoFigma
{
    public partial class Configuracion : Window
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cerrar_sesion(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is Principal)
                {
                    window.Close();
                    break;
                }
            }
            this.Close();
        }

    }
}
