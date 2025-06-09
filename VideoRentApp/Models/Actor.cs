using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoRentApp.Models
{
    // Esta clase debe implementar INotifyPropertyChanged para que la UI se actualice
    // automáticamente cuando cambian sus propiedades (especialmente en el formulario de edición).
    public class Actor : INotifyPropertyChanged
    {
        private int _actorId;
        public int ActorId
        {
            get => _actorId;
            set { _actorId = value; OnPropertyChanged(); }
        }

        private string _nombreActor;
        public string NombreActor
        {
            get => _nombreActor;
            set { _nombreActor = value; OnPropertyChanged(); }
        }

        private string _apellidosActor;
        public string ApellidosActor
        {
            get => _apellidosActor;
            set { _apellidosActor = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
