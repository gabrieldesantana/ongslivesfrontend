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
    public class ExperienciasController : Controller
    {
        private readonly IExperienciaAPI _experienciaAPI;

        public ExperienciasController(IExperienciaAPI experienciaAPI)
        {
            _experienciaAPI = experienciaAPI;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var experiencias = await _experienciaAPI.GetExperiencias();
                return View(experiencias);
            }
            catch (Exception)
            {
                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var experiencia = await _experienciaAPI.GetExperiencia(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                await _experienciaAPI.CreateExperiencia(experiencia);

                return RedirectToAction("Index", "Home");
            }

            return View(experiencia);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var experiencia = await _experienciaAPI.GetExperiencia(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Experiencia experiencia)
        {
            if (id != experiencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _experienciaAPI.UpdateExperiencia(experiencia);
                return RedirectToAction("Index");
            }

            return View(experiencia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var experiencia = await _experienciaAPI.GetExperiencia(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedEdit(int id)
        {
            await _experienciaAPI.DeleteExperiencia(id);
            return RedirectToAction("Index");
        }
    }
}
