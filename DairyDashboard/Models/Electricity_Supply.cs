using System.ComponentModel.DataAnnotations;

namespace DairyDashboard.Models
{
    public class Electricity_Supply
    {
        [Key]
        public int Id { get; set; }
        public string Input_Type { get; set; }  //Grid  , Renewable

        //public ICollection<MachineData> MachineData { get; set; }
    }
}
