namespace CountieAPI.Entities
{
    public class Procedure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFavourite { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
