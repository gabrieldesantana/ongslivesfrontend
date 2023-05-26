using ONGLIVES.API.Entidades;
using System.ComponentModel.DataAnnotations;

namespace OngsLivesFront.MVC.Models
{
    public class LoginModel : Base
    {
        [Required(ErrorMessage = "Digite o login")]
        public string? UsuarioLogin { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? UsuarioSenha { get; set; }
    }
}
