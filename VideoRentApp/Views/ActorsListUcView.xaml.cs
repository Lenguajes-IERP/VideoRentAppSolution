using System.Windows.Controls;
using VideoRentApp.ViewModel;

namespace VideoRentApp.Views
{
    /// <summary>
    /// Interaction logic for ActorsListUcView.xaml
    /// </summary>
    public partial class ActorsListUcView : UserControl
    {
        public ActorsListUcView()
        {
            InitializeComponent();
            this.DataContext = new ActorViewModel();
        }
    }
}
