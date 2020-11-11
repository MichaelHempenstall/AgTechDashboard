using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DairyDashboard.Models
{
    public class MachineData
    {
        [Key]
        public int Id { get; set; }
        public int FarmId { get; set; }
        public int MachineId { get; set; }
        public DateTime ValueDateTime{ get; set; }
        public int CurrentUsage { get; set; }

    }
}
