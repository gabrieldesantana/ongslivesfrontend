using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IUsuarioAPI
    {
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetUsuarioByEmail(string email);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> UpdateSituationAsync(string email);
        Task<bool> DeleteUsuario(int id);


    }
}
