using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Filters;

namespace OngsLivesFront.MVC.Controllers
{
    //[PaginaParaUsuarioLogado]
    //[PaginaRestritaOng]
    [PaginaParaUsuarioLogado]
    public class OngFinanceirosController : Controller
    {
        private readonly OngLivesContext _context;

        public OngFinanceirosController(OngLivesContext context)
        {
            _context = context;
        }

        // GET: OngFinanceiros
        public async Task<IActionResult> Index()
        {
              return _context.TB_OngFinanceiros != null ? 
                          View(await _context.TB_OngFinanceiros.ToListAsync()) :
                          Problem("Entity set 'OngLivesContext.OngFinanceiros'  is null.");
        }

        // GET: OngFinanceiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TB_OngFinanceiros == null)
            {
                return NotFound();
            }

            var ongFinanceiro = await _context.TB_OngFinanceiros
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ongFinanceiro == null)
            {
                return NotFound();
            }

            return View(ongFinanceiro);
        }

        // GET: OngFinanceiros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OngFinanceiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOng,Tipo,Data,Valor,Origem,CriadoEm,Id,Actived")] OngFinanceiro ongFinanceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ongFinanceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ongFinanceiro);
        }

        // GET: OngFinanceiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TB_OngFinanceiros == null)
            {
                return NotFound();
            }

            var ongFinanceiro = await _context.TB_OngFinanceiros.FindAsync(id);
            if (ongFinanceiro == null)
            {
                return NotFound();
            }
            return View(ongFinanceiro);
        }

        // POST: OngFinanceiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOng,Tipo,Data,Valor,Origem,CriadoEm,Id,Actived")] OngFinanceiro ongFinanceiro)
        {
            if (id != ongFinanceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ongFinanceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngFinanceiroExists(ongFinanceiro.Id))
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
            return View(ongFinanceiro);
        }

        // GET: OngFinanceiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TB_OngFinanceiros == null)
            {
                return NotFound();
            }

            var ongFinanceiro = await _context.TB_OngFinanceiros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ongFinanceiro == null)
            {
                return NotFound();
            }

            return View(ongFinanceiro);
        }

        // POST: OngFinanceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TB_OngFinanceiros == null)
            {
                return Problem("Entity set 'OngLivesContext.OngFinanceiros'  is null.");
            }
            var ongFinanceiro = await _context.TB_OngFinanceiros.FindAsync(id);
            if (ongFinanceiro != null)
            {
                _context.TB_OngFinanceiros.Remove(ongFinanceiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngFinanceiroExists(int id)
        {
          return (_context.TB_OngFinanceiros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
