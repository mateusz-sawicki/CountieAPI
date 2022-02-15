using CountieAPI.Models;


namespace CountieAPI.Services
{
    public interface ICategoryService
    {
        public int Create(CreateCategoryDto dto);
        public CategoryDto GetById(int id);
        public IEnumerable<CategoryDto> GetAll();
        public bool Delete(int id);


    }
}
