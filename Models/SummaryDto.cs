using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class SummaryDto
    {
        public DateTime Date { get; set; }
        public decimal DailyQuantity { get; set; }
        public decimal DailySum { get; set; }
        public List<ProcedureForSummaryDto> DailyProcedureSummaryList { get; set; }
    }
}
