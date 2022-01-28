using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Services
{
    public interface IPlannerService
    {
        public DateTime Create(CreatePlannerDto dto);
        public List<ProcedureDto> GetByPlannerDate(DateTime date);
        public IEnumerable<PlannerDto> GetAllPlanners();

    }
    public class PlannerService : IPlannerService
    {
        private readonly CountieDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlannerService(CountieDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProcedureDto> GetByPlannerDate(DateTime date)
        {
            var planner = _dbContext
               .Planners
               .Include(p => p.Procedures)
               .FirstOrDefault(p => p.Date == date);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var proceduresDtos = _mapper.Map<List<ProcedureDto>>(planner.Procedure);
            return proceduresDtos;
        }

        public IEnumerable<PlannerDto> GetAllPlanners()
        {
            var planners = _dbContext
                .Planners
                .Include(p => p.Procedure)
                .ToList();

            var plannersDtos = _mapper.Map<List<PlannerDto>>(planners);
            return plannersDtos;
        }

        public DateTime Create(CreatePlannerDto dto)
        {
            var plannerEntity = _mapper.Map<Planner>(dto);

            _dbContext.Planners.Add(plannerEntity);
            _dbContext.SaveChanges();

            return plannerEntity.Date;
        }
    }
}
