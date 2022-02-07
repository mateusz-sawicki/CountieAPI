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
                .Include(p => p.Procedures)
                .FirstOrDefault(p => p.Date.Date == date.Date);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var result = _mapper.Map<PlannerDto>(planner);
            return result;
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
