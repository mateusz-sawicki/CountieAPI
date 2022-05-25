using CountieAPI.Models;
using System.Security.Claims;

namespace CountieAPI.Services
{
    public interface IPlannerService
    {
        public DateTime Create(CreatePlannerDto dto);
        public PlannersListDto GetByDate(DateTime date, int userId);
        public bool RemoveById(int id);
    }
}