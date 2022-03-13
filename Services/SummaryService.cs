using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountieAPI.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IMapper _mapper;
        private readonly CountieDbContext _dbContext;

        public SummaryService(IMapper mapper, CountieDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<SummaryDto> SummarriesList(DateTime date)
        {
            return null;
        }
        public SummaryDto GetByDate(DateTime date)
        {
            var planner = _dbContext
                .Planners
                .Include(p => p.Procedure)
                .Where(p => p.Date == date);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var result = _mapper.Map<IList<ProcedureForSummaryDto>>(planner).ToList();

            var singleProcedureSummary = new ProcedureForSummaryDto();
            var procedureListSummary = new List<ProcedureForSummaryDto>();


            var groupById = result.GroupBy(p => p.ProcedureId);

            foreach (var group in groupById)
            {
                singleProcedureSummary.Quantity = 0;
                singleProcedureSummary.ProcedurePrice = 0;
                foreach (var item in group)
                {
                    singleProcedureSummary.ProcedureId = item.ProcedureId;
                    singleProcedureSummary.ProcedureName = item.ProcedureName;
                    singleProcedureSummary.Quantity++;
                    singleProcedureSummary.ProcedurePrice = item.ProcedurePrice;
                }

                singleProcedureSummary.ProcedureSum = singleProcedureSummary.Quantity * singleProcedureSummary.ProcedurePrice;
                var summaryOfProcedure = new ProcedureForSummaryDto { 
                    ProcedureId = singleProcedureSummary.ProcedureId, 
                    ProcedureName = singleProcedureSummary.ProcedureName, 
                    ProcedurePrice = singleProcedureSummary.ProcedurePrice, 
                    ProcedureSum = singleProcedureSummary.ProcedureSum, 
                    Quantity = singleProcedureSummary.Quantity 
                };
                procedureListSummary.Add(summaryOfProcedure);
            }

            var summary = new SummaryDto { Date = date, DailyProcedureSummaryList = procedureListSummary };

            foreach (var s in procedureListSummary)
            {
                summary.DailySum += s.ProcedureSum;
                summary.DailyQuantity += s.Quantity;
            }

            return summary;
        }
        public PeriodSummaryDto GetPeriodSummary(DateTime date, string period)
        {
            int day;
            int month = date.Month;
            int year = date.Year;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            SummaryDto dailySummary;
            DateTime dateToIterate;
            var periodSummary = new PeriodSummaryDto();
            var singleProcedureSummary = new ProcedureForSummaryDto();
            var procedureListSummary = new List<ProcedureForSummaryDto>();
            var procedureSummary = new List<ProcedureForSummaryDto>();

            var summary = new List<SummaryDto>();
            periodSummary.Date = date;


            if (period == "month")
            {
                periodSummary.Period = period;
                for (day = 1; day <= daysInMonth; day++)
                {
                    dateToIterate = new DateTime(year, month, day);
                    dailySummary = GetByDate(dateToIterate);
                    var groupedById = dailySummary.DailyProcedureSummaryList.GroupBy(p => p.ProcedureId);
                    foreach (var group in groupedById)
                    {
                        foreach (var item in group)
                        {
                            singleProcedureSummary.ProcedureId = item.ProcedureId;
                            singleProcedureSummary.ProcedureName = item.ProcedureName;
                            singleProcedureSummary.Quantity = item.Quantity;
                            singleProcedureSummary.ProcedurePrice = item.ProcedurePrice;
                        }
                        singleProcedureSummary.ProcedureSum = singleProcedureSummary.Quantity * singleProcedureSummary.ProcedurePrice;
                        var summaryOfProcedure = new ProcedureForSummaryDto
                        {
                            ProcedureId = singleProcedureSummary.ProcedureId,
                            ProcedureName = singleProcedureSummary.ProcedureName,
                            ProcedurePrice = singleProcedureSummary.ProcedurePrice,
                            ProcedureSum = singleProcedureSummary.ProcedureSum,
                            Quantity = singleProcedureSummary.Quantity
                        };
                        procedureListSummary.Add(summaryOfProcedure);
                        
                    }
                    //summary.Add(dailySummary);
                    //periodSummary.PeriodProcedureSummaryList = summary;
                    periodSummary.PeriodTotalQuantity += dailySummary.DailyQuantity;
                    periodSummary.PeriodTotalSum += dailySummary.DailySum;
                }
                var listToGroup = procedureListSummary.GroupBy(p => p.ProcedureId);
                foreach(var group in listToGroup)
                {
                    singleProcedureSummary.Quantity = 0;
                    foreach(var item in group)
                    {
                        singleProcedureSummary.ProcedureId = item.ProcedureId;
                        singleProcedureSummary.ProcedureName= item.ProcedureName;
                        singleProcedureSummary.ProcedurePrice= item.ProcedurePrice;
                        singleProcedureSummary.Quantity += item.Quantity;
                    }
                    singleProcedureSummary.ProcedureSum = singleProcedureSummary.Quantity * singleProcedureSummary.ProcedurePrice;

                    var summaryOfProcedure = new ProcedureForSummaryDto 
                    { 
                        ProcedureId = singleProcedureSummary.ProcedureId, 
                        ProcedureName = singleProcedureSummary.ProcedureName, 
                        Quantity = singleProcedureSummary.Quantity, 
                        ProcedurePrice = singleProcedureSummary.ProcedurePrice, 
                        ProcedureSum = singleProcedureSummary.ProcedureSum 
                    };
                    procedureSummary.Add(summaryOfProcedure);
                    
                }

            }

            periodSummary.ProcedureForSummaryList = procedureSummary;

            return periodSummary;
        }




    }
}
