using CountieAPI.Models;
using CountieAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var newPlannerDate = _plannerService.Create(dto);

            return Created($"app/planner/{newPlannerDate}", null);
        }

        [HttpGet("{date}")]
        public ActionResult GetByDate([FromRoute] DateTime date)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var plannerDto = _plannerService.GetByDate(date, userId);

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