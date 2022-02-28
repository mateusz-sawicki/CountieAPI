using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class PeriodSummary
    {
        public DateTime Date { get; set; }
        public string Period { get; set; }
        public decimal PeriodTotalQuantity { get; set; }
        public decimal PeriodTotalSum { get; set; }
    }
}
