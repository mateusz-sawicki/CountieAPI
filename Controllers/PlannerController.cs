using CountieAPI.Entities;
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
    [Route("app/planner")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerService _plannerService;

        public PlannerController(IPlannerService plannerService)
        {
            _plannerService = plannerService;
        }

        /*        [HttpGet]
                public ActionResult<IEnumerable<Planner>> GetAll()
                {
                    var plannersDtos = _plannerService.GetAll();
                    return Ok(plannersDtos);
                }*/

        [HttpGet("{date}")]
        public ActionResult<List<ProcedureDto>> GetByPlannerDate([FromRoute] DateTime date)
        {
            var proceduresDtos = _plannerService.GetByPlannerDate(date);
            return Ok(proceduresDtos);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePlannerDto dto)
        {
            var newPlannerDate = _plannerService.Create(dto);

            return Created($"app/planner/{newPlannerDate}", null);
        }

        [HttpGet]
        public ActionResult <IEnumerable<PlannerDto>> GetAllPlanners()
        {
            var planners = _plannerService.GetAllPlanners();
            return Ok(planners);
        }

/*        [HttpDelete("{dateTime}")]
        public ActionResult Delete([FromRoute] DateTime dateTime)
        {
            var isDeleted = _plannerService.Delete(dateTime);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }*/
    }
}
