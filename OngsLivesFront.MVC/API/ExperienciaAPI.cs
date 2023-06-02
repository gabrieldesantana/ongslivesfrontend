using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;
using System.Net.Http;

namespace OngsLivesFront.MVC.API
{
    public class ExperienciaAPI : IExperienciaAPI
    {
        private readonly HttpClient _httpClient;

        public ExperienciaAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Experiencia>> GetExperiencias()
        {
            var response = await _httpClient.GetAsync("api/v1/experiencias");
            if (response.IsSuccessStatusCode)
            {
                var experiencias = await response.Content.ReadFromJsonAsync<List<Experiencia>>();
                return experiencias;
            }
            return null;
        }

        public async Task<Experiencia> GetExperiencia(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/experiencias/{id}");
            if (response.IsSuccessStatusCode)
            {
                var experiencia = await response.Content.ReadFromJsonAsync<Experiencia>();
                return experiencia;
            }
            return null;
        }

        public async Task<Experiencia> CreateExperiencia(Experiencia experiencia)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/experiencias", experiencia);

            if (response.IsSuccessStatusCode)
            {
                var experienciaCriado = await response.Content.ReadFromJsonAsync<Experiencia>();
                return experienciaCriado;
            }

            return null;
        }

        public async Task<bool> UpdateExperiencia(Experiencia experiencia)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/experiencias/{experiencia.Id}", experiencia);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteExperiencia(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/experiencias/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
