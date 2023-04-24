using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MZumarraga.Data;
using MZumarraga.Models;

namespace MZumarraga.Controllers
{
    public class MZumarragasController : Controller
    {
        private readonly MZumarragaContext _context;

        public MZumarragasController(MZumarragaContext context)
        {
            _context = context;
        }

        // GET: MZumarragas
        public async Task<IActionResult> Index()
        {
              return _context.MZumarraga != null ? 
                          View(await _context.MZumarraga.ToListAsync()) :
                          Problem("Entity set 'MZumarragaContext.MZumarraga'  is null.");
        }

        // GET: MZumarragas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MZumarraga == null)
            {
                return NotFound();
            }

            var mZumarraga = await _context.MZumarraga
                .FirstOrDefaultAsync(m => m.EANumero == id);
            if (mZumarraga == null)
            {
                return NotFound();
            }

            return View(mZumarraga);
        }

        // GET: MZumarragas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MZumarragas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EANumero,EADecimal,EAString,EABool,EAFecha")] MZumarraga mZumarraga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mZumarraga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mZumarraga);
        }

        // GET: MZumarragas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MZumarraga == null)
            {
                return NotFound();
            }

            var mZumarraga = await _context.MZumarraga.FindAsync(id);
            if (mZumarraga == null)
            {
                return NotFound();
            }
            return View(mZumarraga);
        }

        // POST: MZumarragas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EANumero,EADecimal,EAString,EABool,EAFecha")] MZumarraga mZumarraga)
        {
            if (id != mZumarraga.EANumero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mZumarraga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MZumarragaExists(mZumarraga.EANumero))
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
            return View(mZumarraga);
        }

        // GET: MZumarragas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MZumarraga == null)
            {
                return NotFound();
            }

            var mZumarraga = await _context.MZumarraga
                .FirstOrDefaultAsync(m => m.EANumero == id);
            if (mZumarraga == null)
            {
                return NotFound();
            }

            return View(mZumarraga);
        }

        // POST: MZumarragas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MZumarraga == null)
            {
                return Problem("Entity set 'MZumarragaContext.MZumarraga'  is null.");
            }
            var mZumarraga = await _context.MZumarraga.FindAsync(id);
            if (mZumarraga != null)
            {
                _context.MZumarraga.Remove(mZumarraga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MZumarragaExists(int id)
        {
          return (_context.MZumarraga?.Any(e => e.EANumero == id)).GetValueOrDefault();
        }
    }
}
