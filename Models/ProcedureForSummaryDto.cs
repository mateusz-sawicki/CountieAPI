using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class ProcedureForSummaryDto
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public decimal ProcedurePrice { get; set; }
        public int Quantity { get; set; }
        public decimal ProcedureSum { get; set; }
    }
}
