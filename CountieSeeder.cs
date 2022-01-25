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
                if(!_dbContext.Companies.Any())
                {
                    var companies = GetCompanies();
                    _dbContext.Companies.AddRange(companies);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Company> GetCompanies()
        {
            var companies = new List<Company>()
            {
                new Company()
                {
                    Name = "Willa Dentika",
                    ContactEmail = "willadentika@gmail.com",
                    ContactNumber = "508336676",
                    Procedures = new List<Procedure>()
                    {
                        new Procedure()
                        {
                            Name = "Kompleksowa diagnostyka jamy ustnej",
                            Price = 45.00M,
                            IsFavourite = true,
                            Category = new Category()
                            {
                                Name="Stomatologia zachowawcza"
                            }
                        },
                        new Procedure()
                        {
                            Name = "Trepanacja komory zęba",
                            Price = 33.00M,
                            IsFavourite = true,
                            Category = new Category()
                            {
                                Name="Endodoncja"
                            }
                        }
                    },
                    Address = new Address()
                    {
                        City = "Elbląg",
                        Street = "ul. Saperów 8",
                        ZipCode = "82-300"
                    }
                    
              
                }
                
            };
            return companies;
        }
    }
}
