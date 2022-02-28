using CountieAPI.Models;
using CountieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Controllers
{
    [Route("app/summary")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _summaryService;

        public SummaryController(ISummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        [HttpGet("day/{date}")]
        public ActionResult GetSummary([FromRoute]DateTime date)
        {
            var summary = _summaryService.GetByDate(date);

            return Ok(summary);
        }

        [HttpGet("{period}/{date}")]
        public ActionResult GetPeriodSummary([FromRoute]DateTime date, [FromRoute]string period)
        {
            var periodSummary = _summaryService.GetPeriodSummary(date, period);

            return Ok(periodSummary);
        }
    }
}
