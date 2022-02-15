using AutoMapper;
using CountieAPI.Entities;
using CountieAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CountieAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly CountieDbContext _dbContext;

        public CategoryService(IMapper mapper, CountieDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public int Create(CreateCategoryDto dto)
        {
            var categoryEntity = _mapper.Map<Category>(dto);
            
            _dbContext.Categories.Add(categoryEntity);
            _dbContext.SaveChanges();

            return categoryEntity.Id;
        }

        public CategoryDto GetById(int id)
        {
            var category = _dbContext
                .Categories
                .Include(p => p.Procedures)
                .FirstOrDefault(p => p.Id == id);

            if (category == null)
                throw new Exception("Nie znaleziono kategorii!");

            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _dbContext
                .Categories
                .Include(c => c.Procedures)
                .ToList();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDtos;
        }

        public bool Delete(int id)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Id == id);

            if (category is null)
                return false;

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
