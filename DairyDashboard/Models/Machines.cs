using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Machines
    {
        [Key]
        public int Id { get; set; }
        public string MachineName { get; set; }
    }
}
