using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using CountieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountieAPI.Controllers
{
    [Route("katalog")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpPut]
        public ActionResult Create([FromBody] CreateProcedureDto dto)
        {
            var newProcedureId = _procedureService.Create(dto);
            return Created($"katalog/{newProcedureId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Procedure>> GetAll()
        {
            var proceduresDtos = _procedureService.GetAll();
            return Ok(proceduresDtos);
        }
        [Route("dupa")]
        [HttpGet]
        public ActionResult<IEnumerable<Procedure>> GetAall()
        {
            var proceduresDtos = _procedureService.GetAll();
            return Ok(proceduresDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Procedure> GetById([FromRoute] int id)
        {
            var procedure = _procedureService.GetById(id);

            return Ok(procedure);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _procedureService.Delete(id);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ProcedureDto dto, [FromRoute] int id)
        {
            _procedureService.Update(dto, id);

            return Ok();
        }

    }
}
