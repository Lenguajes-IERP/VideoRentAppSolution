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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoRentApp.ViewModel;

namespace VideoRentApp.Views
{
    /// <summary>
    /// Interaction logic for ActorFormUcView.xaml
    /// </summary>
    public partial class ActorFormUcView : UserControl
    {
        public ActorFormUcView()
        {
            InitializeComponent();
        }
        private void OnGuardarClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ActorViewModel vm)
            {
                vm.SaveCommand.Execute(null);
            }
        }
    }
}
