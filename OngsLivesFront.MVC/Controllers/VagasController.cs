using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Filters;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Controllers
{
    //[PaginaRestritaOng]
    [PaginaParaUsuarioLogado]
    public class VagasController : Controller
    {
        private readonly IVagaAPI _vagaAPI;

        private readonly IOngAPI _ongAPI;

        public VagasController(IVagaAPI vagaAPI, IOngAPI ongAPI)
        {
            _vagaAPI = vagaAPI;
            _ongAPI = ongAPI;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var vagas = await _vagaAPI.GetVagas();
                return View(vagas);
            }
            catch (Exception)
            {

                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }


        }

        public async Task<IActionResult> Details(int id)
        {
            var vaga = await _vagaAPI.GetVaga(id);

            var ong = await _ongAPI.GetOng(vaga.IdOng);

            ViewBag.Ong = ong;

            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        public async Task<IActionResult> VagasByOngId([FromRoute]int id)
        {
             var ido = id;
            var ong = await _ongAPI.GetOng(id);

            //var vagas = await _vagaAPI.GetVagas();

            if (ong == null)
            {
                return NotFound();
            }

            //ViewData["OngId"] = 

            return View(ong);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                await _vagaAPI.CreateVaga(vaga);

                return RedirectToAction("Index", "Home");
            }

            return View(vaga);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vaga = await _vagaAPI.GetVaga(id);

            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _vagaAPI.UpdateVaga(vaga);
                return RedirectToAction("Index");
            }

            return View(vaga);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _vagaAPI.GetVaga(id);

            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vagaAPI.DeleteVaga(id);
            return RedirectToAction("Index");
        }
    }
}
