using ONGLIVES.API.Entidades;
using OngsLivesFront.MVC.Models.Enums;

namespace OngsLivesFront.MVC.Models
{
    public class Usuario : Base
    {
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario Perfil { get; set; }
        public string? Senha { get; set; }

        public DateTime CriadoEm { get; set; }

        public bool SenhaValida(string senha) => this.Senha == senha;
    }
}
