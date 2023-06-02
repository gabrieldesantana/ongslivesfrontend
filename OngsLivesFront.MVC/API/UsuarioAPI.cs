using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API
{
    public class UsuarioAPI : IUsuarioAPI
    {
        private readonly HttpClient _httpClient;

        public UsuarioAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            var response = await _httpClient.GetAsync("api/v1/usuarios");
            if (response.IsSuccessStatusCode)
            {
                var usuarios = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                return usuarios;
            }
            return null;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/usuarios/{id}");
            if (response.IsSuccessStatusCode)
            {
                var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                return usuario;
            }
            return null;
        }

        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/v1/usuarios/email/{email}");
            if (response.IsSuccessStatusCode)
            {
                var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                return usuario;
            }
            return null;
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/usuarios", usuario);

            if (response.IsSuccessStatusCode)
            {
                var usuarioCriado = await response.Content.ReadFromJsonAsync<Usuario>();
                return usuarioCriado;
            }

            return null;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/usuarios/{usuario.Id}", usuario);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateSituationAsync(string email)
        {
            var usuario = await GetUsuarioByEmail(email);

            var response = await _httpClient.GetAsync($"api/v1/usuarios/changeStatus/{usuario.Id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/usuarios/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
