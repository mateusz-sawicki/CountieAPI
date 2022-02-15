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
        public ProcedureDto Procedure { get; set; }
        public decimal DailySummary { get; set; }

        public List<ProcedureDto> ProceduresList { get; set; }

    }
}
