using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.ViewComponents
{
    public class MenuBaixo : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            //return View(usuario);

            CadastroModel cadastroModel = new CadastroModel();
            cadastroModel.Usuario = usuario;
            cadastroModel.Voluntario = new Voluntario("", "", DateTime.Now, "", "", "", "", "", 0, 0, 0, new Endereco());
            cadastroModel.Ong = new Ong("", "", "", "", "", 0, new Endereco());

            return View(cadastroModel);
        }
    }
}
