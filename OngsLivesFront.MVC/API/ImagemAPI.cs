using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class ImagemAPI : IImagemAPI
    {
        private readonly HttpClient _httpClient;

        public ImagemAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Imagem>> GetImagens()
        {
            var response = await _httpClient.GetAsync("api/v1/imagens");
            if (response.IsSuccessStatusCode)
            {
                var imagems = await response.Content.ReadFromJsonAsync<List<Imagem>>();
                return imagems;
            }
            return null;
        }

        public async Task<Imagem> GetImagem(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/imagens/{id}");
            if (response.IsSuccessStatusCode)
            {
                var imagem = await response.Content.ReadFromJsonAsync<Imagem>();
                return imagem;
            }
            return null;
        }

        public async Task<Imagem> CreateImagem(Imagem imagem)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/imagens", imagem);

            if (response.IsSuccessStatusCode)
            {
                var imagemCriado = await response.Content.ReadFromJsonAsync<Imagem>();
                return imagemCriado;
            }

            return null;
        }

        public async Task<bool> UpdateImagem(Imagem imagem)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/imagens/{imagem.Id}", imagem);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteImagem(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/imagens/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
