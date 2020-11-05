using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DairyDashboard;
using DairyDashboard.Models;

namespace DairyDashboard.Controllers
{
    public class FarmsController : Controller
    {
        private readonly DatabaseContext _context;

        public FarmsController(DatabaseContext context)
        {
            _context = context;
        }

        public FarmsController()
        {
        }

        // GET: Farms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farms.ToListAsync());
        }

        public List<Farms> GetFarms()
        {
            return _context.Farms.ToList();
        }

        // GET: Farms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farms = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farms == null)
            {
                return NotFound();
            }

            return View(farms);
        }

        // GET: Farms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FarmName")] Farms farms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farms);
        }

        // GET: Farms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farms = await _context.Farms.FindAsync(id);
            if (farms == null)
            {
                return NotFound();
            }
            return View(farms);
        }

        // POST: Farms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FarmName")] Farms farms)
        {
            if (id != farms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmsExists(farms.Id))
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
            return View(farms);
        }

        // GET: Farms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farms = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farms == null)
            {
                return NotFound();
            }

            return View(farms);
        }

        // POST: Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farms = await _context.Farms.FindAsync(id);
            _context.Farms.Remove(farms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmsExists(int id)
        {
            return _context.Farms.Any(e => e.Id == id);
        }
    }
}
