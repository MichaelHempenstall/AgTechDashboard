using DairyDashboard.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace DairyDashboard.Services
{
    public class DatabaseCollectionService
    {
        public DatabaseCollectionService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        //private string JsonDatabase()
        ///{ }
        ///

        //public IEnumerable<MachineData> GetMachineData()
        //{
        //    using var biz = MachineData();
        //}

    }
}
