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
    //[PaginaRestritaVoluntario]
    [PaginaParaUsuarioLogado]
    public class VoluntariosController : Controller
    {
        private readonly OngLivesContext _context;

        public VoluntariosController(OngLivesContext context)
        {
            _context = context;
        }

        // GET: Voluntarios
        public async Task<IActionResult> Index()
        {
              return _context.TB_Voluntarios != null ? 
                          View(await _context.TB_Voluntarios.ToListAsync()) :
                          Problem("Entity set 'OngLivesContext.Voluntarios'  is null.");
        }

        // GET: Voluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TB_Voluntarios == null)
            {
                return NotFound();
            }

            var voluntario = await _context.TB_Voluntarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // GET: Voluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CPF,DataNascimento,Escolaridade,Genero,Email,Telefone,Habilidade,QuantidadeExperiencias,Id")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                voluntario.Actived= true;
                voluntario.CriadoEm = DateTime.Now;
                voluntario.Avaliacao = 5;
                voluntario.HorasVoluntaria = 0;
                _context.Add(voluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TB_Voluntarios == null)
            {
                return NotFound();
            }

            var voluntario = await _context.TB_Voluntarios.FindAsync(id);
            if (voluntario == null)
            {
                return NotFound();
            }
            return View(voluntario);
        }

        // POST: Voluntarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,CPF,DataNascimento,Escolaridade,Genero,Email,Telefone,Habilidade,Avaliacao,HorasVoluntaria,QuantidadeExperiencias,CriadoEm,Id,Actived")] Voluntario voluntario)
        {
            if (id != voluntario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioExists(voluntario.Id))
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
            return View(voluntario);
        }

        // GET: Voluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TB_Voluntarios == null)
            {
                return NotFound();
            }

            var voluntario = await _context.TB_Voluntarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TB_Voluntarios == null)
            {
                return Problem("Entity set 'OngLivesContext.Voluntarios'  is null.");
            }
            var voluntario = await _context.TB_Voluntarios.FindAsync(id);
            if (voluntario != null)
            {
                _context.TB_Voluntarios.Remove(voluntario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioExists(int id)
        {
          return (_context.TB_Voluntarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
