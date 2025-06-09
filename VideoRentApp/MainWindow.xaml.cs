using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoRentApp.Views;

namespace VideoRentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Cierra la aplicación
        }
        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }

        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Cierra la aplicación
        }

        private void Actores_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí cargarías OtroUserControl si lo tuvieras.");
            // Crea una nueva instancia de la ventana 
            //MantenimientoActoresWindow actorsWindow = new MantenimientoActoresWindow();
            // Muestra la ventana.
            // ShowDialog() la muestra modalmente (bloquea la ventana principal).
            // Show() la muestra no modalmente. 
            //actorsWindow.ShowDialog();
            MainContentArea.Content = new ActorsListUcView();

        }
    }
}