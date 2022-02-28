namespace CountieAPI.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }  

        public List<ProcedureDto> Procedures { get; set; }
    }
}
