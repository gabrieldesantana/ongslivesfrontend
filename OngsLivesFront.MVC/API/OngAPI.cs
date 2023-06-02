using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class OngAPI : IOngAPI
    {
        private readonly HttpClient _httpClient;

        public OngAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ong>> GetOngs()
        {
            var response = await _httpClient.GetAsync("api/v1/ongs");
            if (response.IsSuccessStatusCode)
            {
                var ongs = await response.Content.ReadFromJsonAsync<List<Ong>>();
                return ongs;
            }
            return null;
        }

        public async Task<Ong> GetOng(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/ongs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var ong = await response.Content.ReadFromJsonAsync<Ong>();
                return ong;
            }
            return null;
        }

        public async Task<Ong> GetOngByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/v1/ongs/email/{email}");
            if (response.IsSuccessStatusCode)
            {
                var ong = await response.Content.ReadFromJsonAsync<Ong>();
                return ong;
            }
            return null;
        }

        public async Task<Ong> CreateOng(Ong ong)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/ongs", ong);

            if (response.IsSuccessStatusCode)
            {
                var ongCriado = await response.Content.ReadFromJsonAsync<Ong>();
                return ongCriado;
            }

            return null;
        }

        public async Task<bool> UpdateOng(Ong ong)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/ongs/{ong.Id}", ong);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOng(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/ongs/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
