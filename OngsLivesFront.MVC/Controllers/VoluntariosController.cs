using Microsoft.AspNetCore.Mvc;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.Controllers;

public class VoluntariosController : Controller
{
    private readonly IVoluntarioAPI _voluntarioAPI;
    private readonly IUsuarioAPI _usuarioAPI;

    public VoluntariosController(IVoluntarioAPI voluntarioAPI, IUsuarioAPI usuarioAPI)
    {
        _voluntarioAPI = voluntarioAPI;
        _usuarioAPI = usuarioAPI;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var voluntarios = await _voluntarioAPI.GetVoluntarios();
            return View(voluntarios);
        }
        catch (Exception)
        {

            return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
        }
    }

    public IActionResult Perfil(int id)
    {
        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        var voluntario = await _voluntarioAPI.GetVoluntario(id);

        if (voluntario == null)
        {
            return NotFound();
        }

        return View(voluntario);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Voluntario voluntario)
    {
        if (ModelState.IsValid)
        {
            await _voluntarioAPI.CreateVoluntario(voluntario);
            await _usuarioAPI.UpdateSituationAsync(voluntario.Email);

            return RedirectToAction("Index", "Home");
        }

        return View(voluntario);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var voluntario = await _voluntarioAPI.GetVoluntario(id);

        if (voluntario == null)
        {
            return NotFound();
        }

        return View(voluntario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Voluntario voluntario)
    {
        if (id != voluntario.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _voluntarioAPI.UpdateVoluntario(voluntario);
            return RedirectToAction("Index");
        }

        return View(voluntario);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var voluntario = await _voluntarioAPI.GetVoluntario(id);

        if (voluntario == null)
        {
            return NotFound();
        }

        return View(voluntario);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
        await _voluntarioAPI.DeleteVoluntario(id);
        return RedirectToAction("Index");
    }
}
