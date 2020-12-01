using DairyDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DairyDashboard.Controllers
{
    public class FarmsController : Controller
    {
        private readonly AgTechContext _context;

        public FarmsController(AgTechContext context)
        {
            _context = context;
        }

        // GET: Farms
        public async Task<IActionResult> Index()
        {

            return View(await _context.Farms.ToListAsync());
        }

        // GET: Farms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
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
        public async Task<IActionResult> Create([Bind("Id,FarmName")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farm);
        }

        // GET: Farms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }
            return View(farm);
        }

        // POST: Farms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FarmName")] Farm farm)
        {
            if (id != farm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmExists(farm.Id))
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
            return View(farm);
        }

        // GET: Farms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // POST: Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmExists(int id)
        {
            return _context.Farms.Any(e => e.Id == id);
        }

        public ActionResult Dashboard()
        {
            var usageData = _context.MachineData.ToList();

            List<object> obj = new List<object>();
            
            var UsageDate = usageData.Select(x => x.ValueDateTime).ToArray();
            var Usage = usageData.Select(x => x.CurrentUsage).ToArray();
            obj.Add(UsageDate);
            obj.Add(Usage);

            return Json(obj);                
        }

        public ActionResult GetSingleFarmData(int farmId)
        {
            var usageData = _context.MachineData.ToList();

            List<object> obj = new List<object>();

            var singleFarmData = usageData.Where(x => x.FarmId == farmId).ToArray();
            var machinery = singleFarmData.Select(x => x.MachineId).ToList().Distinct();
            
            foreach (var item in machinery)
            {
                var machineName = _context.Machines.Where(x => x.Id == item).FirstOrDefault();
                var UsageDate = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var UsageDates = UsageDate.Select(x => x.ValueDateTime).ToArray();
                var Usage = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var Usages = Usage.Select(x => x.CurrentUsage).ToArray();
                obj.Add(machineName.MachineName);
                obj.Add(UsageDates);
                obj.Add(Usages);
            }

            return Json(obj);
        }
    }
}