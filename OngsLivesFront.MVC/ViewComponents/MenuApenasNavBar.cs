using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.ViewComponents
{
    [EnableCors("")]
    public class MenuApenasNavBar : ViewComponent
    {

        private readonly IOngAPI _ongAPI;
        private readonly IVoluntarioAPI _voluntarioAPI;

        public MenuApenasNavBar(IOngAPI ongAPI, IVoluntarioAPI voluntarioAPI)
        {
            _ongAPI = ongAPI;
            _voluntarioAPI = voluntarioAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            CadastroModel cadastroModel = new CadastroModel();
            cadastroModel.Usuario = usuario;
            cadastroModel.Voluntario = new Voluntario ("","",DateTime.Now,"","","","","",0,0,0,new Endereco());
            cadastroModel.Ong = new Ong("", "", "", "", "", 0, new Endereco());


            if (usuario.Perfil == Models.Enums.EPerfilUsuario.Admin) 
            {
                //
            }

            if (usuario.Perfil == Models.Enums.EPerfilUsuario.Voluntario && usuario.Actived == true)
            {
                cadastroModel.Voluntario = await _voluntarioAPI.GetVoluntarioByEmail(usuario.Email);
            }

            if (usuario.Perfil == Models.Enums.EPerfilUsuario.Ong && usuario.Actived == true)
            {
                cadastroModel.Ong = await _ongAPI.GetOngByEmail(usuario.Email);
            }

            return View(cadastroModel);
        }
    }
}
