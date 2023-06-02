using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Filters;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Controllers
{
    //[PaginaParaUsuarioLogado]
    //[PaginaRestritaOng]
    [PaginaParaUsuarioLogado]
    public class OngFinanceirosController : Controller
    {
        private readonly IOngFinanceiroAPI _voluntarioAPI;

        public OngFinanceirosController(IOngFinanceiroAPI voluntarioAPI)
        {
            _voluntarioAPI = voluntarioAPI;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var voluntarios = await _voluntarioAPI.GetOngFinanceiros();
                return View(voluntarios);
            }
            catch (Exception)
            {
                return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var voluntario = await _voluntarioAPI.GetOngFinanceiro(id);

            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(OngFinanceiro voluntario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _voluntarioAPI.CreateOngFinanceiro(voluntario);

        //        return RedirectToAction("Index");
        //    }

        //    return View(voluntario);
        //}

        public async Task<IActionResult> Edit(int id)
        {
            var voluntario = await _voluntarioAPI.GetOngFinanceiro(id);

            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OngFinanceiro voluntario)
        {
            if (id != voluntario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _voluntarioAPI.UpdateOngFinanceiro(voluntario);
                return RedirectToAction("Index");
            }

            return View(voluntario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var voluntario = await _voluntarioAPI.GetOngFinanceiro(id);

            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _voluntarioAPI.DeleteOngFinanceiro(id);
            return RedirectToAction("Index");
        }
    }
}
