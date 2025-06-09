using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Windows;
using VideoRentApp.Services;
using VideoRentApp.Models;

namespace VideoRentApp.ViewModel
{
    public class ActorViewModel: ObservableObject
    {
        private readonly ActorApiService _apiService;
        private ObservableCollection<Actor> _actors;
        private Actor _selectedActor;
        private bool _isLoading;

        public ObservableCollection<Actor> Actors
        {
            get => _actors;
            set { _actors = value; OnPropertyChanged(); }
        }

        public Actor SelectedActor
        {
            get => _selectedActor;
            set { _selectedActor = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand AddActorCommand { get; }
        public IAsyncRelayCommand EditActorCommand { get; }
        public IAsyncRelayCommand DeleteActorCommand { get; }

        public ActorViewModel()
        {
            _apiService = new ActorApiService();
            Actors = new ObservableCollection<Actor>();

            AddActorCommand = new AsyncRelayCommand(AddActor);
            EditActorCommand = new AsyncRelayCommand(EditActor);
            DeleteActorCommand = new AsyncRelayCommand(DeleteActor);

            //  "fire-and-forget" an async task in a constructor
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

        private async Task AddActor()
        {
            var newActor = new Actor();
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

        private async Task EditActor()
        {

           /* if (SelectedActor == null) return;

            var actorToEdit = new Actor
            {
                ActorId = SelectedActor.ActorId,
                NombreActor = SelectedActor.NombreActor,
                ApellidosActor = SelectedActor.ApellidosActor
            };

            var detailWindow = new ActorDetailWindow(actorToEdit);
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
        }
    }
}
