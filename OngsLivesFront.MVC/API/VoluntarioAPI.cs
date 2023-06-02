using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class VoluntarioAPI : IVoluntarioAPI
    {
        private readonly HttpClient _httpClient;

        public VoluntarioAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Voluntario>> GetVoluntarios()
        {
            var response = await _httpClient.GetAsync("api/v1/voluntarios");
            if (response.IsSuccessStatusCode)
            {
                var voluntarios = await response.Content.ReadFromJsonAsync<List<Voluntario>>();
                return voluntarios;
            }
            return null;
        }

        public async Task<Voluntario> GetVoluntario(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/voluntarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                var voluntario = await response.Content.ReadFromJsonAsync<Voluntario>();
                return voluntario;
            }
            return null;
        }

        public async Task<Voluntario> GetVoluntarioByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/v1/voluntarios/email/{email}");
            if (response.IsSuccessStatusCode)
            {
                var voluntario = await response.Content.ReadFromJsonAsync<Voluntario>();
                return voluntario;
            }
            return null;
        }

        public async Task<Voluntario> CreateVoluntario(Voluntario voluntario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/voluntarios", voluntario);

            if (response.IsSuccessStatusCode)
            {
                var voluntarioCriado = await response.Content.ReadFromJsonAsync<Voluntario>();
                return voluntarioCriado;
            }

            return null;
        }

        public async Task<bool> UpdateVoluntario(Voluntario voluntario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/voluntarios/{voluntario.Id}", voluntario);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVoluntario(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/voluntarios/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
