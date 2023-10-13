using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using swimming.Models;

namespace swimming.Controllers
{
    public class SwimmingController : Controller
    {
        private readonly MVCSwimmingContext _context;

        public SwimmingController(MVCSwimmingContext context)
        {
            _context = context;
        }

        // GET: Swimming
        public async Task<IActionResult> Index()
        {
            return View(await _context.Swimming.ToListAsync());
        }

        // GET: Swimming/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Swimming/NotFound.cshtml");
            }

            var swimming = await _context.Swimming
                .FirstOrDefaultAsync(m => m.Id == id);
            if (swimming == null)
            {
                return View("~/Views/Swimming/NotFound.cshtml");
            }

            return View(swimming);
        }

        // GET: Swimming/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Swimming/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoolName,PoolLength,PoolLocation,PoolCapacity,PoolTimings,PoolDays")] Swimming swimming)
        {
            if (ModelState.IsValid)
            {
                _context.Add(swimming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(swimming);
        }

        // GET: Swimming/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Swimming/NotFound.cshtml");
            }

            var swimming = await _context.Swimming.FindAsync(id);
            if (swimming == null)
            {
                return View("~/Views/Swimming/NotFound.cshtml");
            }
            return View(swimming);
        }

        // POST: Swimming/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoolName,PoolLength,PoolLocation,PoolCapacity,PoolTimings,PoolDays")] Swimming swimming)
        {
            if (id != swimming.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(swimming);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SwimmingExists(swimming.Id))
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
            return View(swimming);
        }

        // GET: Swimming/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swimming = await _context.Swimming
                .FirstOrDefaultAsync(m => m.Id == id);
            if (swimming == null)
            {
                return NotFound();
            }

            return View(swimming);
        }

        // POST: Swimming/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var swimming = await _context.Swimming.FindAsync(id);
            _context.Swimming.Remove(swimming);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SwimmingExists(int id)
        {
            return _context.Swimming.Any(e => e.Id == id);
        }
    }
}
