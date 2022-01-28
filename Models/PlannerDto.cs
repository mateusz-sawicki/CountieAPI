using CountieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class PlannerDto
    {
        public DateTime Date { get; set; }
        public List<ProcedureDto> Procedures { get; set; }
        public string ProcedureName { get; set; }
    }
}
