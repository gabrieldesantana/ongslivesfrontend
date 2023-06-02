using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class VagaAPI : IVagaAPI
    {
        private readonly HttpClient _httpClient;

        public VagaAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Vaga>> GetVagas()
        {
            var response = await _httpClient.GetAsync("api/v1/vagas");
            if (response.IsSuccessStatusCode)
            {
                var vagas = await response.Content.ReadFromJsonAsync<List<Vaga>>();
                return vagas;
            }
            return null;
        }

        public async Task<Vaga> GetVaga(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/vagas/{id}");
            if (response.IsSuccessStatusCode)
            {
                var vaga = await response.Content.ReadFromJsonAsync<Vaga>();
                return vaga;
            }
            return null;
        }

        public async Task<Vaga> CreateVaga(Vaga vaga)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/vagas", vaga);

            if (response.IsSuccessStatusCode)
            {
                var vagaCriado = await response.Content.ReadFromJsonAsync<Vaga>();
                return vagaCriado;
            }

            return null;
        }

        public async Task<bool> UpdateVaga(Vaga vaga)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/vagas/{vaga.Id}", vaga);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVaga(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/vagas/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
