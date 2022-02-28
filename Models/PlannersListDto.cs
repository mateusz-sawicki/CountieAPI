using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class PlannersListDto
    {
        public DateTime Date { get; set; }
        public List<PlannerDto> PlannersList { get; set; } 
    }
}
