using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Helpers
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
