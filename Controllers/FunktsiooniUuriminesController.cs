using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunctionApp.Data;
using FunctionApp.Models;

namespace FunctionApp.Controllers
{
    public class FunktsiooniUuriminesController : Controller
    {
        private readonly AppDbContext _context;

        public FunktsiooniUuriminesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FunktsiooniUurimines
        public async Task<IActionResult> Index()
        {
            return View(await _context.FunktsiooniUurimised.ToListAsync());
        }

        // GET: FunktsiooniUurimines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funktsiooniUurimine = await _context.FunktsiooniUurimised
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funktsiooniUurimine == null)
            {
                return NotFound();
            }

            return View(funktsiooniUurimine);
        }

        // GET: FunktsiooniUurimines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FunktsiooniUurimines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valem,Maaramispiirkond,Tuletis,KriitilisedPunktid,Ekstreemumid,LuodudAeg")] FunktsiooniUurimine funktsiooniUurimine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funktsiooniUurimine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funktsiooniUurimine);
        }

        // GET: FunktsiooniUurimines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funktsiooniUurimine = await _context.FunktsiooniUurimised.FindAsync(id);
            if (funktsiooniUurimine == null)
            {
                return NotFound();
            }
            return View(funktsiooniUurimine);
        }

        // POST: FunktsiooniUurimines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valem,Maaramispiirkond,Tuletis,KriitilisedPunktid,Ekstreemumid,LuodudAeg")] FunktsiooniUurimine funktsiooniUurimine)
        {
            if (id != funktsiooniUurimine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funktsiooniUurimine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunktsiooniUurimineExists(funktsiooniUurimine.Id))
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
            return View(funktsiooniUurimine);
        }

        // GET: FunktsiooniUurimines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funktsiooniUurimine = await _context.FunktsiooniUurimised
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funktsiooniUurimine == null)
            {
                return NotFound();
            }

            return View(funktsiooniUurimine);
        }

        // POST: FunktsiooniUurimines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funktsiooniUurimine = await _context.FunktsiooniUurimised.FindAsync(id);
            if (funktsiooniUurimine != null)
            {
                _context.FunktsiooniUurimised.Remove(funktsiooniUurimine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunktsiooniUurimineExists(int id)
        {
            return _context.FunktsiooniUurimised.Any(e => e.Id == id);
        }
    }
}
