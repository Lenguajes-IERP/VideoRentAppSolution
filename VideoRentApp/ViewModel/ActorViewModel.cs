using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using VideoRentApp.Services;
using VideoRentApp.Models;
using System.Windows.Input;
using VideoRentApp.Views;

namespace VideoRentApp.ViewModel
{
    // TODO correccion
    public partial class ActorViewModel: ObservableObject
    {
        private readonly ActorApiService _apiService;

        [ObservableProperty]
        private ObservableCollection<Actor> _actors;


        // CORRECCIÓN
        // El atributo [NotifyCanExecuteChangedFor] notifica automáticamente a los comandos
        // cuando esta propiedad cambia. Esto reemplaza la lógica manual en el 'setter'.
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditActorCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteActorCommand))]
        private Actor _selectedActor;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool _isEditingOrAdding; // TODO para editar

        [ObservableProperty]
        private Actor _actorInEdit; //TODO para editar

        //Comandos
        public IRelayCommand AddActorCommand { get; }
        public IRelayCommand EditActorCommand { get; }
        public IAsyncRelayCommand DeleteActorCommand { get; }
        // TODO para editar
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public ActorViewModel()
        {
            _apiService = new ActorApiService();
            Actors = new ObservableCollection<Actor>();

            AddActorCommand = new RelayCommand(AddActor);
            // Ga
            EditActorCommand = new RelayCommand(EditActor, () => SelectedActor != null);
            DeleteActorCommand = new AsyncRelayCommand(DeleteActor, () => SelectedActor != null);

            // TODO Comandos del formulario
            SaveCommand = new RelayCommand(async () => await SaveActor());
            CancelCommand = new RelayCommand(Cancel);

            IsEditingOrAdding = true;
            //  Cargado asíncrono de los actores
            _ = LoadActorsAsync();
        }

        private async Task LoadActorsAsync()
        {
            IsLoading = true;
            var actorsList = await _apiService.GetActorsAsync();
            Actors.Clear();
            foreach (var actor in actorsList)
            {
                Actors.Add(actor);
            }
            IsLoading = false;
        }

        // TODO corrección
        private void AddActor()
        {
            ActorInEdit = new Actor();
            IsEditingOrAdding = true;

            /*var detailWindow = new ActorDetailWindow(newActor);
            if (detailWindow.ShowDialog() == true)
            {
                try
                {
                    var addedActor = await _apiService.AddActorAsync(newActor);
                    Actors.Add(addedActor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al añadir actor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }*/
        }

        // TODO corrección
        private void EditActor()
        {
            // TODO código para editar

           if (SelectedActor == null) return;

            ActorInEdit = new Actor
            {
                ActorId = SelectedActor.ActorId,
                NombreActor = SelectedActor.NombreActor,
                ApellidosActor = SelectedActor.ApellidosActor
            };
            IsEditingOrAdding = true;

            /*var actorForm = new ActorFormUcView(actorToEdit);
            if (detailWindow.ShowDialog() == true)
            {
                try
                {
                    await _apiService.UpdateActorAsync(actorToEdit);
                    var index = Actors.IndexOf(SelectedActor);
                    if (index != -1)
                    {
                        Actors[index] = actorToEdit;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar actor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }*/
        }

        private async Task DeleteActor()
        {
            if (SelectedActor == null) return;

            if (MessageBox.Show($"¿Seguro que quieres eliminar a {SelectedActor.NombreActor} {SelectedActor.ApellidosActor}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    await _apiService.DeleteActorAsync(SelectedActor.ActorId);
                    Actors.Remove(SelectedActor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar actor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }//DeleteActor


        //TODO para editar
        private async Task SaveActor()
        {
            if (ActorInEdit == null || string.IsNullOrWhiteSpace(ActorInEdit.NombreActor) || string.IsNullOrWhiteSpace(ActorInEdit.ApellidosActor))
            {
                MessageBox.Show("El nombre y los apellidos son obligatorios.", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            IsLoading = true;
            try
            {
                if (ActorInEdit.ActorId == 0) // Nuevo actor
                {
                    await _apiService.AddActorAsync(ActorInEdit);
                }
                else // Actor existente
                {
                    await _apiService.UpdateActorAsync(ActorInEdit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el actor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsEditingOrAdding = false;
                await LoadActorsAsync(); // Recargar la lista para mostrar los cambios
            }
        }
        // para editar
        private void Cancel()
        {
            IsEditingOrAdding = false;
            ActorInEdit = null;
        }
    }
}
