using SqlKata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvisor.Db.Models.Entities
{
    [Table("DistrictTemperatures")]
    public class DistrictTemperature
    {
        [Key]
        public long Id {get; set;}
        public string District {get; set;}
        public DateTime Date {get; set;}
        public string Time {get; set;}
        public double Temperature {get; set;}
        public string Unit {get; set;}
    }
}
