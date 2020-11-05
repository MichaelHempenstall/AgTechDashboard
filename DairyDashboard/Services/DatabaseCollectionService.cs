using DairyDashboard.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;

namespace DairyDashboard.Services
{
    public class DatabaseCollectionService
    {
        public DatabaseCollectionService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        //private string DatabaseConnection()
        //{
        //    //get { return Path.Combine(WebHostEnvironment.WebRootPath, "database", "AgTech.db") };
        //}
        

        //public IEnumerable<MachineData> GetMachineData()
        //{
        //    using var biz = MachineData();
        //}

    }
}
