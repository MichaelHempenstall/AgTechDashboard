﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }
        public string FarmName { get; set; }

        public ICollection<MachineData> MachineData { get; set; }
    }
}