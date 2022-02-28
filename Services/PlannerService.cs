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
    public class PlannerService : IPlannerService
    {
        private readonly CountieDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlannerService(CountieDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public PlannersListDto GetByDate(DateTime date)
        {
            var planner = _dbContext
                .Planners
                .Include(p => p.Procedure)
                .Include(p => p.Procedure.Category)
                .Where(p => p.Date == date);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var result = _mapper.Map<IList<PlannerDto>>(planner).ToList() ;

            var plannerList = new PlannersListDto { Date = date, PlannersList = result };

            return plannerList;
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