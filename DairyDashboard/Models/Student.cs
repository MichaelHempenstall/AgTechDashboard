using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
