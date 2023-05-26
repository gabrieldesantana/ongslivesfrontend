using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Repository
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorLogin(string login);
    }
}
