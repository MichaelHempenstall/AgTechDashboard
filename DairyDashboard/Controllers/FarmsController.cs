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

        public async Task<IActionResult> CompareFarms()
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

        /// <summary>
        /// Sample return for the dashboard
        /// </summary>
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

        /// <summary>
        /// Take the farm Id from the javascript call and return the usage data for that farm
        /// </summary>
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
                var AvgUseTemp = Usage.Average(x => x.CurrentUsage).ToString();
                var AvgUse = Math.Round(Decimal.Parse(AvgUseTemp), 2);
                var MinUse = Usage.Min(x => x.CurrentUsage).ToString();
                var MaxUse = Usage.Max(x => x.CurrentUsage).ToString();

                obj.Add(machineName.MachineName);
                obj.Add(UsageDates);
                obj.Add(Usages);
                obj.Add(AvgUse);
                obj.Add(MinUse);
                obj.Add(MaxUse);
            }

            return Json(obj);
        }

        public ActionResult Show_Week()
        {
            int farmId = 1;
            var usageData = _context.MachineData.ToList();

            List<object> obj = new List<object>();

            DateTime dateStart = new DateTime(2020, 11, 08);
            DateTime dateEnd = new DateTime(2020, 11, 14);
            var singleFarmData = usageData.Where(x => x.FarmId == farmId && x.ValueDateTime >= dateStart && x.ValueDateTime <= dateEnd).ToArray();
            var machinery = singleFarmData.Select(x => x.MachineId).ToList().Distinct();

            foreach (var item in machinery)
            {
                var machineName = _context.Machines.Where(x => x.Id == item).FirstOrDefault();
                var UsageDate = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var UsageDates = UsageDate.Select(x => x.ValueDateTime).ToArray();
                var Usage = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var Usages = Usage.Select(x => x.CurrentUsage).ToArray();
                var AvgUseTemp = Usage.Average(x => x.CurrentUsage).ToString();
                var AvgUse = Math.Round(Decimal.Parse(AvgUseTemp), 2);
                var MinUse = Usage.Min(x => x.CurrentUsage).ToString();
                var MaxUse = Usage.Max(x => x.CurrentUsage).ToString();

                obj.Add(machineName.MachineName);
                obj.Add(UsageDates);
                obj.Add(Usages);
                obj.Add(AvgUse);
                obj.Add(MinUse);
                obj.Add(MaxUse);
            }

            return Json(obj);
        }

        public ActionResult Show_Month()
        {
            int farmId = 1;
            var usageData = _context.MachineData.ToList();

            List<object> obj = new List<object>();

            DateTime dateStart = new DateTime(2020, 11, 01);
            DateTime dateEnd = new DateTime(2020, 11, 30);
            var singleFarmData = usageData.Where(x => x.FarmId == farmId && x.ValueDateTime >= dateStart && x.ValueDateTime <= dateEnd).ToArray();
            var machinery = singleFarmData.Select(x => x.MachineId).ToList().Distinct();

            foreach (var item in machinery)
            {
                var machineName = _context.Machines.Where(x => x.Id == item).FirstOrDefault();
                var UsageDate = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var UsageDates = UsageDate.Select(x => x.ValueDateTime).ToArray();
                var Usage = singleFarmData.Where(x => x.MachineId == item).ToArray();
                var Usages = Usage.Select(x => x.CurrentUsage).ToArray();
                var AvgUseTemp = Usage.Average(x => x.CurrentUsage).ToString();
                var AvgUse = Math.Round(Decimal.Parse(AvgUseTemp), 2);
                var MinUse = Usage.Min(x => x.CurrentUsage).ToString();
                var MaxUse = Usage.Max(x => x.CurrentUsage).ToString();

                obj.Add(machineName.MachineName);
                obj.Add(UsageDates);
                obj.Add(Usages);
                obj.Add(AvgUse);
                obj.Add(MinUse);
                obj.Add(MaxUse);
            }

            return Json(obj);
        }

        /// <summary>
        /// Take the farm Id from the javascript call and return the usage data for that farm
        /// and the average data from the other farms
        /// Also return the electricity usage 
        /// </summary>
        public ActionResult GetCompareFarmData(int farmId)
        {
            var usageData = _context.MachineData.ToList();
            var electricityData = _context.Electricity_Usage.ToList();

            List<object> obj = new List<object>();

            //get farmid data 
            var singleFarmData = usageData.Where(x => x.FarmId == farmId && x.CurrentUsage > 0).ToArray();
            var singleFarmSum = 0;
            foreach (var item in singleFarmData)
            {
                singleFarmSum += item.CurrentUsage;                
            }

            //get all other data 
            var compareFarmData = usageData.Where(x => x.FarmId != farmId && x.CurrentUsage > 0).ToArray();
            var compareFarmSum = 0;
            foreach (var item in compareFarmData)
            {
                compareFarmSum += item.CurrentUsage;
            }
            compareFarmSum = compareFarmSum / 4;

            var singleFarmEnergy = electricityData.Where(x => x.FarmId == farmId && x.CurrentUsage > 0).ToArray();
            var singleFarmEnergySum = 0;
            foreach (var item in singleFarmEnergy)
            {
                singleFarmEnergySum += item.CurrentUsage;
            }

            //get all other data 
            var compareFarmEnergy = electricityData.Where(x => x.FarmId != farmId && x.CurrentUsage > 0).ToArray();
            var compareFarmEnergySum = 0;
            foreach (var item in compareFarmEnergy)
            {
                compareFarmEnergySum += item.CurrentUsage;
            }
            compareFarmEnergySum = compareFarmEnergySum / 4;

            obj.Add(singleFarmSum);
            obj.Add(compareFarmSum);
            obj.Add(singleFarmEnergySum);
            obj.Add(compareFarmEnergySum);
            
            return Json(obj);
        }
    }
}