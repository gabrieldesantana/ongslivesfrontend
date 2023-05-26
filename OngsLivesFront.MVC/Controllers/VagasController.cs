using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Filters;

namespace OngsLivesFront.MVC.Controllers
{
    //[PaginaRestritaOng]
    [PaginaParaUsuarioLogado]
    public class VagasController : Controller
    {
        private readonly OngLivesContext _context;

        public VagasController(OngLivesContext context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
              return _context.TB_Vagas != null ? 
                          View(await _context.TB_Vagas.ToListAsync()) :
                          Problem("Entity set 'OngLivesContext.Vagas'  is null.");
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TB_Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.TB_Vagas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vagas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoluntario,IdOng,Tipo,Turno,Descricao,Habilidade,DataInicio,DataFim,CriadoEm,Id,Actived")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TB_Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.TB_Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoluntario,IdOng,Tipo,Turno,Descricao,Habilidade,DataInicio,DataFim,CriadoEm,Id,Actived")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TB_Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.TB_Vagas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TB_Vagas == null)
            {
                return Problem("Entity set 'OngLivesContext.Vagas'  is null.");
            }
            var vaga = await _context.TB_Vagas.FindAsync(id);
            if (vaga != null)
            {
                _context.TB_Vagas.Remove(vaga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
          return (_context.TB_Vagas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
