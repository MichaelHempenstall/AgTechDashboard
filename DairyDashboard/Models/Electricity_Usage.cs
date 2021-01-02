using System;
using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Electricity_Usage
    {
        [Key]
        public int Id { get; set; }
        public int FarmId { get; set; }
        public int TypeId { get; set; }  //Grid  , Renewable
        public DateTime ValueDateTime { get; set; }
        public int CurrentUsage { get; set; }
    }
}
