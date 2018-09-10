using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceVitas.Models;

namespace ReceVitas.Controllers
{
    public class PatologiasController : Controller
    {
        private readonly RecetasContext _context;

        public PatologiasController(RecetasContext context)
        {
            _context = context;
        }

        // GET: Patologias
        public async Task<IActionResult> Index()
        {
            return View(await _context.patologias.ToListAsync());
        }

        // GET: Patologias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patologias = await _context.patologias
                .FirstOrDefaultAsync(m => m.id_pat == id);
            if (patologias == null)
            {
                return NotFound();
            }

            return View(patologias);
        }

        // GET: Patologias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patologias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pat,codigo,descripcion,activo")] Patologias patologias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patologias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patologias);
        }

        // GET: Patologias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patologias = await _context.patologias.FindAsync(id);
            if (patologias == null)
            {
                return NotFound();
            }
            return View(patologias);
        }

        // POST: Patologias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_pat,codigo,descripcion,activo")] Patologias patologias)
        {
            if (id != patologias.id_pat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patologias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatologiasExists(patologias.id_pat))
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
            return View(patologias);
        }

        // GET: Patologias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patologias = await _context.patologias
                .FirstOrDefaultAsync(m => m.id_pat == id);
            if (patologias == null)
            {
                return NotFound();
            }

            return View(patologias);
        }

        // POST: Patologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patologias = await _context.patologias.FindAsync(id);
            _context.patologias.Remove(patologias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatologiasExists(int id)
        {
            return _context.patologias.Any(e => e.id_pat == id);
        }
    }
}
