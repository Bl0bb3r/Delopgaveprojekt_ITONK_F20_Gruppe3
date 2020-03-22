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
    public class VaerktoejsController : Controller
    {
        private readonly AppDbContext.AppDbContext _context;

        public VaerktoejsController(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        // GET: Vaerktoejs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaerktoejer.ToListAsync());
        }

        // GET: Vaerktoejs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejer
                .FirstOrDefaultAsync(m => m.VTID == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaerktoejs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VTID,VTFabrikat,VTSerienr,VTModel,VTType,VTAnskaffet,LiggerIvtk")] Vaerktoej vaerktoej)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaerktoej);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejer.FindAsync(id);
            if (vaerktoej == null)
            {
                return NotFound();
            }
            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VTID,VTFabrikat,VTSerienr,VTModel,VTType,VTAnskaffet,LiggerIvtk")] Vaerktoej vaerktoej)
        {
            if (id != vaerktoej.VTID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaerktoej);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaerktoejExists(vaerktoej.VTID))
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
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejer
                .FirstOrDefaultAsync(m => m.VTID == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vaerktoej = await _context.Vaerktoejer.FindAsync(id);
            _context.Vaerktoejer.Remove(vaerktoej);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaerktoejExists(long id)
        {
            return _context.Vaerktoejer.Any(e => e.VTID == id);
        }
    }
}
