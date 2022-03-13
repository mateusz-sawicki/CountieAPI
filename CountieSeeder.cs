using CountieAPI.Entities;

namespace CountieAPI
{
    public class CountieSeeder
    {
        private readonly CountieDbContext _dbContext;
        public CountieSeeder(CountieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "User"
                }
            };
            return roles;
        }
        private IEnumerable<Procedure> GetProcedures()
        {
            var procedures = new List<Procedure>()
            {
                new Procedure()
                {
                    Name = "Kompleksowa diagnostyka jamy ustnej",
                    Price = 55.00M,
                    IsFavourite = true,
                    CategoryId = 1
                }
            };
            return procedures;
        }
        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Zachowawcza"
                },
                new Category()
                {
                    Name = "Endodoncja"
                },
                new Category()
                {
                    Name = "Badania i konsultacje"
                },
                new Category()
                {
                    Name = "RTG"
                },
                new Category()
                {
                    Name = "Dzieci"
                },
                new Category()
                {
                    Name = "Sedacja"
                },
                new Category()
                {
                    Name = "Chirurgia"
                },
                new Category()
                {
                    Name = "Protetyka"
                },
                new Category()
                {
                    Name = "Naprawy"
                },
                new Category()
                {
                    Name = "Implantoprotetyka"
                },
                new Category()
                {
                    Name = "Higienizacja"
                }
            };
            return categories;
        }
    }
}
