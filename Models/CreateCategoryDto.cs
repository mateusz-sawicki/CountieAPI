using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public virtual List<ProcedureDto> Procedures { get; set; }
    }
}
