using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class OngFinanceiroAPI : IOngFinanceiroAPI
    {
        private readonly HttpClient _httpClient;

        public OngFinanceiroAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OngFinanceiro>> GetOngFinanceiros()
        {
            var response = await _httpClient.GetAsync("api/v1/ongFinanceiros");
            if (response.IsSuccessStatusCode)
            {
                var ongFinanceiros = await response.Content.ReadFromJsonAsync<List<OngFinanceiro>>();
                return ongFinanceiros;
            }
            return null;
        }

        public async Task<OngFinanceiro> GetOngFinanceiro(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/ongFinanceiros/{id}");
            if (response.IsSuccessStatusCode)
            {
                var ongFinanceiro = await response.Content.ReadFromJsonAsync<OngFinanceiro>();
                return ongFinanceiro;
            }
            return null;
        }

        //public async Task<OngFinanceiro> CreateOngFinanceiro(OngFinanceiro ongFinanceiro)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/v1/ongFinanceiros", ongFinanceiro);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var ongFinanceiroCriado = await response.Content.ReadFromJsonAsync<OngFinanceiro>();
        //        return ongFinanceiroCriado;
        //    }

        //    return null;
        //}

        public async Task<bool> UpdateOngFinanceiro(OngFinanceiro ongFinanceiro)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/ongFinanceiros/{ongFinanceiro.Id}", ongFinanceiro);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOngFinanceiro(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/ongFinanceiros/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
