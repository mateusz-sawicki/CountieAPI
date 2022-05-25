using AutoMapper;
using CountieAPI.Authorization;
using CountieAPI.Entities;
using CountieAPI.Exceptions;
using CountieAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CountieAPI.Services
{
    public class PlannerService : IPlannerService
    {
        private readonly CountieDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public PlannerService(CountieDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public PlannersListDto GetByDate(DateTime date, int userId)
        {
            var planner = _dbContext
                .Planners
                .Include(p => p.Procedure)
                .Include(p => p.Procedure.Category)
                .Where(p => p.Date == date)
                .Where(p => p.CreatedById == userId);

            if (planner == null)
                throw new Exception("Nie znaleziono planu");

            var result = _mapper.Map<IList<PlannerDto>>(planner).ToList() ;

            var plannerList = new PlannersListDto { Date = date, PlannersList = result };

            return plannerList;
        }


        public DateTime Create(CreatePlannerDto dto)
        {
            var plannerEntity = _mapper.Map<Planner>(dto);
            plannerEntity.CreatedById = _userContextService.GetUserId;
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

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, planner, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            _dbContext.Planners.Remove(planner);
            _dbContext.SaveChanges();

            return true;
        }


    }
}