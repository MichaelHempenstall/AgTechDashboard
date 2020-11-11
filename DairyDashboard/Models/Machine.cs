using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Machine
    {
        [Key]
        public int Id { get; set; }
        public string MachineName { get; set; }

        public ICollection<MachineData> MachineDatas { get; set; }
    }
}
