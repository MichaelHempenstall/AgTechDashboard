using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Farms
    {
        [Key]
        public int Id { get; set; }
        public string FarmName { get; set; }
    }
}
