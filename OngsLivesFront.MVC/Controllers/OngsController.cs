using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Filters;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class OngsController : Controller
    {
        private readonly IOngAPI _ongAPI;
        private readonly IUsuarioAPI _usuarioAPI;

        public OngsController(IOngAPI ongAPI, IUsuarioAPI usuarioAPI)
        {
            _ongAPI = ongAPI;
            _usuarioAPI = usuarioAPI;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var ongs = await _ongAPI.GetOngs();
                return View(ongs);
            }
            catch (Exception)
            {
                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }
        }

        //public async Task<IActionResult> Perfil([FromRoute] int iditem)
        public async Task<IActionResult> Perfil(int id)
        {
            try
            {
                var ong = _ongAPI.GetOng(id);
                return View(ong);
            }
            catch (Exception)
            {
                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }
        }

        //public async Task<IActionResult> Index_new()
        //{
        //    try
        //    {
        //        var ongs = await _ongAPI.GetOngs();
        //        return View(ongs);
        //    }
        //    catch (Exception)
        //    {
        //        return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
        //    }
        //}

        public async Task<IActionResult> Details(int id)
        {
            var ong = await _ongAPI.GetOng(id);

            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ong ong)
        {
            if (ModelState.IsValid)
            {
                await _ongAPI.CreateOng(ong);
                await _usuarioAPI.UpdateSituationAsync(ong.Email);

                return RedirectToAction("Index", "Home");

            }

            return View(ong);
        }

        //[Bind("Nome,CPF,DataNascimento,Escolaridade,Genero,Email,Telefone,Habilidade,QuantidadeExperiencias,Id")] Voluntario voluntario

        public async Task<IActionResult> Edit(int id)
        {
            var ong = await _ongAPI.GetOng(id);

            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ong ong)
        {
            if (id != ong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _ongAPI.UpdateOng(ong);
                return RedirectToAction("Index");
            }

            return View(ong);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ong = await _ongAPI.GetOng(id);

            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ongAPI.DeleteOng(id);
            return RedirectToAction("Index");
        }
    }
}
