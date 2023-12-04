using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Tasks;
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
            IQueryable<string> poolnameQuery = from m in _context.Swimming
                                            orderby m.PoolName
                                            select m.PoolName;
            var swimming = from m in _context.Swimming
                        select m;
                        swimming = swimming.Where(x => x.Selected == false);
            var swimmingPoolName = new SwimmingPoolNameViewModel
            {
                PoolName = new SelectList(await poolnameQuery.Distinct().ToListAsync()),
                Swimming = await swimming.ToListAsync()
            };

            return View(swimmingPoolName);
        }

        [HttpPost]
       public async Task<IActionResult> Hide(int[] selectedSwimming)
       {
           IQueryable<string> typeQuery = from m in _context.Swimming
                                           select m.PoolName;
           var swimming = from m in _context.Swimming
                       select m;
           
            foreach (var poolName in selectedSwimming)
            {
                var swimming1 = await _context.Swimming.FindAsync(poolName);
                swimming1.Selected = true;
                await _context.SaveChangesAsync();
            }
            swimming = swimming.Where(x => x.Selected == false);

           var swimmingPoolName = new SwimmingPoolNameViewModel
           {
               PoolName = new SelectList(await typeQuery.Distinct().ToListAsync()),
               Swimming = await swimming.ToListAsync()
           };
           return View("Index", swimmingPoolName);
       }
       public async Task<IActionResult> Hide()
       {
           IQueryable<string> typeQuery = from m in _context.Swimming
                                           select m.PoolName;
           var swimming = from m in _context.Swimming
                       select m;
           
            swimming = swimming.Where(x => x.Selected == true);

           var swimmingPoolName = new SwimmingPoolNameViewModel
           {
               PoolName = new SelectList(await typeQuery.Distinct().ToListAsync()),
               Swimming = await swimming.ToListAsync()
           };
           return View(swimmingPoolName);
       }
        public async Task<IActionResult> Search(string swimmingPoolName, DateTime entryDeadline, string searchParamString, decimal poolSizeSearchNumber)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> poolnameQuery = from m in _context.Swimming
                                            select m.PoolName;
            var swimming = from m in _context.Swimming
                        select m;
            if (!string.IsNullOrEmpty(swimmingPoolName))
            {
                swimming = swimming.Where(x => x.PoolName == swimmingPoolName);
            }
            if (entryDeadline != DateTime.MinValue)
            {
                swimming = swimming.Where(x => x.EntryDeadline == entryDeadline);
            }
            if (!string.IsNullOrEmpty(searchParamString))
            {
                swimming = swimming.Where(x => x.PoolLocation == searchParamString);
            }
            if (poolSizeSearchNumber > 0)
            {
                swimming = swimming.Where(x => x.PoolSize == poolSizeSearchNumber);
            }
            swimming = swimming.Where(x => x.Selected == false);
            var swimmingPoolName1 = new SwimmingPoolNameViewModel
            {
                PoolName = new SelectList(await poolnameQuery.Distinct().ToListAsync()),
                Swimming = await swimming.ToListAsync()
            };

            return View("index",swimmingPoolName1);
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
        public async Task<IActionResult> Create([Bind("Id,PoolName,PoolLength,PoolLocation,PoolCapacity,PoolTimings,PoolDays,PoolSize,EntryDeadline")] Swimming swimming)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoolName,PoolLength,PoolLocation,PoolCapacity,PoolTimings,PoolDays,PoolSize,EntryDeadline")] Swimming swimming)
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

        public async Task<IActionResult> DeleteAll()
        {
            IQueryable<string> poolnameQuery = from m in _context.Swimming
                                            orderby m.PoolName
                                            select m.PoolName;
            var swimming = from m in _context.Swimming
                        select m;
                        swimming = swimming.Where(x => x.Selected == true);
                        foreach(var swimmingItem in swimming)
                    {
                        var records = await _context.Swimming.FindAsync(swimmingItem.Id);
                        records.Selected = false;
                        await _context.SaveChangesAsync();
                    }
            var swimmingPoolName = new SwimmingPoolNameViewModel
            {
                PoolName = new SelectList(await poolnameQuery.Distinct().ToListAsync()),
                Swimming = await swimming.ToListAsync()
            };

            return View("Index",swimmingPoolName);
        }
    }

}
