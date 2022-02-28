using CountieAPI.Models;

namespace CountieAPI.Services
{
    public interface IPlannerService
    {
        public DateTime Create(CreatePlannerDto dto);
        public PlannersListDto GetByDate(DateTime date);
        public bool RemoveById(int id);
    }
}