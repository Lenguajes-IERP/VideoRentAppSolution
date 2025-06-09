using System.Net.Http;
using System.Net.Http.Json;
using VideoRentApp.Models;

namespace VideoRentApp.Services
{
    public class ActorApiService
    {
        private static readonly HttpClient client = new HttpClient();
        // La URL base ahora se lee desde el archivo de configuración global
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public ActorApiService()
        {
          
            if (client.BaseAddress == null)
            {
                if (string.IsNullOrEmpty(baseUrl))
                {
                    throw new InvalidOperationException("La URL base de la API no está configurada en appsettings.json.");
                }
                client.BaseAddress = new Uri(baseUrl);
            }
        }

        /// <summary>
        /// Llama a GET: api/actors
        /// </summary>
        public async Task<List<Actor>> GetActorsAsync()
        {
            try
            {
                var actors = await client.GetFromJsonAsync<List<Actor>>("api/actors");
                return actors ?? new List<Actor>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al obtener actores: {e.Message}");
                return new List<Actor>();
            }
        }

        /// <summary>
        /// Llama a POST: api/actors
        /// </summary>
        public async Task<Actor> AddActorAsync(Actor actor)
        {
            var response = await client.PostAsJsonAsync("api/actors", actor);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Actor>();
        }

        /// <summary>
        /// Llama a PUT: api/actors/{id}
        /// </summary>
        public async Task UpdateActorAsync(Actor actor)
        {
            var response = await client.PutAsJsonAsync($"api/actors/{actor.ActorId}", actor);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Llama a DELETE: api/actors/{id}
        /// </summary>
        public async Task DeleteActorAsync(int actorId)
        {
            var response = await client.DeleteAsync($"api/actors/{actorId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
