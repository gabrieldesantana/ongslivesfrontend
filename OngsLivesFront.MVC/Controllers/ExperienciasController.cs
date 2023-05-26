using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Filters;

namespace OngsLivesFront.MVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ExperienciasController : Controller
    {
        private readonly OngLivesContext _context;

        public ExperienciasController(OngLivesContext context)
        {
            _context = context;
        }

        #region READ

        // GET: Experiencias
        public async Task<IActionResult> Index()
        {
              //return _context.Experiencias != null ? 
              //            View(await _context.Experiencias.ToListAsync()) :
              //            Problem("Entity set 'OngLivesContext.Experiencias'  is null.");
              var experiencias = await _context.TB_Experiencias.ToListAsync();

            return View(experiencias);
            //return Problem("Entity set 'OngLivesContext.Experiencias'  is null.");
        }

        // GET: Experiencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TB_Experiencias == null)
            {
                return NotFound();
            }

            var experiencia = await _context.TB_Experiencias
                .FirstOrDefaultAsync(m => m.Id == id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        #endregion

        #region CREATE

        // GET: Experiencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoluntario,IdOng,NomeVoluntario,NomeOng,ProjetoEnvolvido,Opiniao,DataPostagem,DataExperienciaInicio,DataExperienciaFim,CriadoEm,Id,Actived")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencia);
        }

        #endregion

        #region EDIT

        // GET: Experiencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TB_Experiencias == null)
            {
                return NotFound();
            }

            var experiencia = await _context.TB_Experiencias.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoluntario,IdOng,NomeVoluntario,NomeOng,ProjetoEnvolvido,Opiniao,DataPostagem,DataExperienciaInicio,DataExperienciaFim,CriadoEm,Id,Actived")] Experiencia experiencia)
        {
            if (id != experiencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaExists(experiencia.Id))
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
            return View(experiencia);
        }

        #endregion

        #region DELETE

        // GET: Experiencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TB_Experiencias == null)
            {
                return NotFound();
            }

            var experiencia = await _context.TB_Experiencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TB_Experiencias == null)
            {
                return Problem("Entity set 'OngLivesContext.Experiencias'  is null.");
            }
            var experiencia = await _context.TB_Experiencias.FindAsync(id);
            if (experiencia != null)
            {
                _context.TB_Experiencias.Remove(experiencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        private bool ExperienciaExists(int id)
        {
          return (_context.TB_Experiencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
