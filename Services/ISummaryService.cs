using CountieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Services
{
    public interface ISummaryService
    {
        public SummaryDto GetByDate(DateTime date);

        public List<SummaryDto> SummarriesList(DateTime date);

        public PeriodSummary GetPeriodSummary(DateTime date, string period);

    }
}
