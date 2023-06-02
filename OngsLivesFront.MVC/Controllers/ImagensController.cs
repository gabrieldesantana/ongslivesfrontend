using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.Models;
using OngsLivesFront.MVC.Repository;

namespace OngsLivesFront.MVC.Controllers
{
    public class ImagensController : Controller
    {
        private readonly IImagemAPI _imagemAPI;
        private readonly OngLivesContext _context;

        public ImagensController(IImagemAPI imagemAPI, OngLivesContext context)
        {
            _imagemAPI = imagemAPI;
            _context = context;
        }

        // GET: Imagems
        //public async Task<IActionResult> Index()
        //{
        //      return _context.TB_Imagens != null ? 
        //                  View(await _context.TB_Imagens.ToListAsync()) :
        //                  Problem("Entity set 'OngLivesContext.TB_Imagens'  is null.");
        //}

        // GET: Imagems/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.TB_Imagens == null)
        //    {
        //        return NotFound();
        //    }

        //    var imagem = await _context.TB_Imagens
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (imagem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(imagem);
        //}

        // GET: Imagems/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Imagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Conteudo")] Imagem imagem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(imagem);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(imagem);
        //}

        //// GET: Imagems/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TB_Imagens == null)
        //    {
        //        return NotFound();
        //    }

        //    var imagem = await _context.TB_Imagens.FindAsync(id);
        //    if (imagem == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(imagem);
        //}

        // POST: Imagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Conteudo")] Imagem imagem)
        //{
        //    if (id != imagem.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(imagem);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ImagemExists(imagem.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(imagem);
        //}

        // GET: Imagems/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TB_Imagens == null)
        //    {
        //        return NotFound();
        //    }

        //    var imagem = await _context.TB_Imagens
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (imagem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(imagem);
        //}

        // POST: Imagems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TB_Imagens == null)
        //    {
        //        return Problem("Entity set 'OngLivesContext.TB_Imagens'  is null.");
        //    }
        //    var imagem = await _context.TB_Imagens.FindAsync(id);
        //    if (imagem != null)
        //    {
        //        _context.TB_Imagens.Remove(imagem);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ImagemExists(int id)
        //{
        //  return (_context.TB_Imagens?.Any(e => e.Id == id)).GetValueOrDefault();
        //}


        #region Metodos API

        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        var imagens = await _imagemAPI.GetImagens();
        //        return View(imagens);
        //    }
        //    catch (Exception)
        //    {

        //        return Problem(" Erro 500: Favor contactar o Administrador do Sistema");
        //    }
        //}

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var imagem = await _imagemAPI.GetImagem(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        public IActionResult Create2()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1(Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                await _imagemAPI.CreateImagem(imagem);

                return RedirectToAction("Index");
            }

            return View(imagem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var imagem = await _imagemAPI.GetImagem(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imagem imagem)
        {
            if (id != imagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _imagemAPI.UpdateImagem(imagem);
                return RedirectToAction("Index");
            }

            return View(imagem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var imagem = await _imagemAPI.GetImagem(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _imagemAPI.DeleteImagem(id);
            return RedirectToAction("Index");
        }

        #endregion


        #region Metodos View

        [HttpPost]
        public async Task<IActionResult> Upload()
        {

            var file = Request.Form.Files[0];

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    var imagem = new Imagem
                    {
                        Nome = file.FileName,
                        Conteudo = memoryStream.ToArray()
                    };

                    await _imagemAPI.CreateImagem(imagem);

                    //_context.TB_Imagens.Add(imagem);
                    //await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Visualizar(int id)
        {
            var imagem = await _context.TB_Imagens.FindAsync(id);

            if (imagem != null)
            {
                return File(imagem.Conteudo, "image/jpeg");
            }

            return NotFound();
        }
        

        public async Task<IActionResult> Excluir(int id)
        {
            var imagem = await _context.TB_Imagens.FindAsync(id);

            if (imagem != null)
            {
                _context.TB_Imagens.Remove(imagem);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            var imagem = await _context.TB_Imagens.FindAsync(id);

            if (imagem != null)
            {
                return File(imagem.Conteudo, "application/octet-stream", imagem.Nome);
            }

            return NotFound();
        }

        #endregion
    }
}
