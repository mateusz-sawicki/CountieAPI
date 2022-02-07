namespace CountieAPI.Models
{
    public class CategoryDto
    {
        public string Name { get; set; }  

        public List<ProcedureDto> Procedures { get; set; }
    }
}
