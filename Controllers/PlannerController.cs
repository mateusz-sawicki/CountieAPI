using CountieAPI.Entities;
using CountieAPI.Models;
using CountieAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]

    public class PlannerController : ControllerBase
    {
        private readonly IPlannerService _plannerService;

        public PlannerController(IPlannerService plannerService)
        {
            _plannerService = plannerService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePlannerDto dto)
        {
            var newPlannerDate = _plannerService.Create(dto);

            return Created($"app/planner/{newPlannerDate}", null);
        }

        [HttpGet("{date}")]
        public ActionResult GetByDate([FromRoute] DateTime date)
        {
            var plannerDto = _plannerService.GetByDate(date);

            return Ok(plannerDto);
        }

        [HttpDelete("{date}/{plannerId}")]
        public ActionResult DeleteById([FromRoute] int plannerId)
        {
            _plannerService.RemoveById(plannerId);

            return NoContent();
        }
        [HttpPut("{date}/{plannerId}")]
        public ActionResult UpdateById([FromRoute] int plannerId, [FromBody] PlannerDto dto)
        {
            return Ok(dto);
        }
    }
}