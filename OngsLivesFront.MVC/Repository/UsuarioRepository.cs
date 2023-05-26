using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OngLivesContext _context;
        public UsuarioRepository(OngLivesContext context) 
        { 
            _context= context;
        }
        public Usuario BuscarPorLogin(string login)
        {
            return _context.TB_Usuarios.FirstOrDefault(x => x.Login == login);
        }
    }
}
