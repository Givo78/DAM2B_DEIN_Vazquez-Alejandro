using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProyectoFigma
{
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            CargarFeed("cerca");
        }

        private void CargarFeed(string tipo)
        {
            FeedPanel.Children.Clear();

            if (tipo == "cerca")
            {
                CrearPost("https://images.unsplash.com/photo-1504208434309-cb69f4fe52b0",
                          "Aventura en carretera con los colegas 🚗🔥");

                CrearPost("https://images.unsplash.com/photo-1500534623283-312aade485b7",
                          "Trayecto compartido hacia la uni 🎓🚙");
            }
            else if (tipo == "caminar")
            {
                CrearPost("https://images.unsplash.com/photo-1485965120184-e220f721d03e",
                          "Explorando la ciudad a pie 🚶‍♂️🌆");

                CrearPost("https://images.unsplash.com/photo-1500530855697-b586d89ba3ee",
                          "Paseo por el parque con buena música 🎧🌳");
            }
            else if (tipo == "coche")
            {
                CrearPost("https://images.unsplash.com/photo-1502877338535-766e1452684a",
                          "Compartiendo coche rumbo al trabajo 🚙💨");

                CrearPost("https://images.unsplash.com/photo-1483721310020-03333e577078",
                          "Viaje exprés con nuevos amigos 🚗🤝");
            }
        }

        private void CrearPost(string imagenUrl, string texto)
        {
            var border = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(20),
                Margin = new Thickness(0, 10, 0, 10),
                Padding = new Thickness(10)
            };

            var stack = new StackPanel();

            var imagen = new Image
            {
                Source = new BitmapImage(new System.Uri(imagenUrl)),
                Height = 200,
                Stretch = Stretch.UniformToFill,
                Margin = new Thickness(0, 0, 0, 10),
                ClipToBounds = true
            };

            var textoPost = new TextBlock
            {
                Text = texto,
                FontSize = 14,
                Foreground = Brushes.Black,
                TextWrapping = TextWrapping.Wrap
            };

            var likeButton = new ToggleButton
            {
                Width = 40,
                Height = 40,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = System.Windows.Input.Cursors.Hand
            };

            likeButton.Click += LikeButton_Click;
            likeButton.Content = new TextBlock { Text = "♡", FontSize = 20, Foreground = Brushes.Gray };

            stack.Children.Add(imagen);
            stack.Children.Add(textoPost);
            stack.Children.Add(likeButton);

            border.Child = stack;
            FeedPanel.Children.Add(border);
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton btn)
            {
                if (btn.IsChecked == true)
                    btn.Content = new TextBlock { Text = "❤", FontSize = 20, Foreground = Brushes.Red };
                else
                    btn.Content = new TextBlock { Text = "♡", FontSize = 20, Foreground = Brushes.Gray };
            }
        }

        private void CercaDeTi_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CargarFeed("cerca");
        }

        private void Caminar_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CargarFeed("caminar");
        }

        private void NecesitasCoche_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CargarFeed("coche");
        }

        private void AbrirConfiguracion_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Configuracion config = new Configuracion();
            config.ShowDialog();
        }

    }
}
