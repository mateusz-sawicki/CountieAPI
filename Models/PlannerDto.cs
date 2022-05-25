using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class PlannerDto
    {
        public int PlannerId { get; set; }
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public decimal ProcedurePrice { get; set; }
        public string CategoryName { get; set; }
        public int? CreatedById { get; set; }


    }
}
