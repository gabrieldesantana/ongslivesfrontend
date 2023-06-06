
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngsLivesFront.MVC.Helpers;
using OngsLivesFront.MVC.Models;
using OngsLivesFront.MVC.Repository;
using System.Diagnostics;

namespace OngsLivesFront.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se o usuario estiver logado, redirecionar para a Home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index","Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
            //return Ok();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel login)
        {
            

            //if (usuario != null)
            //{
            //    return BadRequest();
            //}

          


            //return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepository.BuscarPorLogin(login.UsuarioLogin);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.UsuarioSenha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha é invalida";
                    }

                    TempData["MensagemErro"] = $"Usuario e/ou senha inválido(s). Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}