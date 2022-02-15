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
        public PlannerDto GetByDate(DateTime date);
        public bool RemoveById(int id);
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

        public PlannerDto GetByDate(DateTime date)
        {
            var planner = _dbContext
                .Planners
                .Where(p => p.Date.Date == date.Date)
                .Include(p => p.Procedure)
                .Include(p => p.Procedure.Category);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var mappedPlanner = _mapper.Map<IList<PlannerDto>>(planner).ToList();

            var result = new PlannerDto { Date = date, ProceduresList = new List<ProcedureDto>() };

            mappedPlanner.ForEach(r => result.ProceduresList.Add(r.Procedure));

            foreach (var p in mappedPlanner)
            {
                result.DailySummary += p.Procedure.Price;
            }

            return result;
        }

        public DateTime Create(CreatePlannerDto dto)
        {
            var plannerEntity = _mapper.Map<Planner>(dto);

            _dbContext.Planners.Add(plannerEntity);
            _dbContext.SaveChanges();

            return plannerEntity.Date;
        }

        public bool RemoveById(int id)
        {
            var planner = _dbContext
                .Planners
                .FirstOrDefault(p => p.Id == id);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");


            _dbContext.Planners.Remove(planner);
            _dbContext.SaveChanges();

            return true;
        }


    }
}
