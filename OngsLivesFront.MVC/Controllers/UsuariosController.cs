using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Filters;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Controllers
{
    //[PaginaRestritaAdmin]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAPI _usuarioAPI;

        public UsuariosController(IUsuarioAPI usuarioAPI)
        {
            _usuarioAPI = usuarioAPI;
        }
        [PaginaRestritaAdmin]
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _usuarioAPI.GetUsuarios();
                return View(usuarios);
            }
            catch (Exception)
            {
                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuarioAPI.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [PaginaRestritaAdmin]
        public IActionResult CreateAdmin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioAPI.CreateUsuario(usuario);

                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioAPI.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _usuarioAPI.UpdateUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioAPI.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioAPI.DeleteUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
