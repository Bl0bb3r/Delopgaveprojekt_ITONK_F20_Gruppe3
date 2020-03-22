using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Delopgaveprojekt_ITONK_F20_Gruppe3.AppDbContext;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Controllers
{
    public class HaandvaerkersController : Controller
    {
        private readonly AppDbContext.AppDbContext _context;

        public HaandvaerkersController(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        // GET: Haandvaerkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Haandvaerkere.ToListAsync());
        }

        // GET: Haandvaerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkere
                .FirstOrDefaultAsync(m => m.HaandvaerkerID == id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haandvaerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HaandvaerkerID,HVFornavn,HVEfternavn,HVAnsaettelsedato,HVFagomraade")] Haandvaerker haandvaerker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haandvaerker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkere.FindAsync(id);
            if (haandvaerker == null)
            {
                return NotFound();
            }
            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HaandvaerkerID,HVFornavn,HVEfternavn,HVAnsaettelsedato,HVFagomraade")] Haandvaerker haandvaerker)
        {
            if (id != haandvaerker.HaandvaerkerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haandvaerker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaandvaerkerExists(haandvaerker.HaandvaerkerID))
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
            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkere
                .FirstOrDefaultAsync(m => m.HaandvaerkerID == id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haandvaerker = await _context.Haandvaerkere.FindAsync(id);
            _context.Haandvaerkere.Remove(haandvaerker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaandvaerkerExists(int id)
        {
            return _context.Haandvaerkere.Any(e => e.HaandvaerkerID == id);
        }
    }
}
