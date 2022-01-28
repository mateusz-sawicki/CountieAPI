namespace CountieAPI.Entities
{
    public class Planner
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public List<Procedure> Procedures { get; set; }
    }
}
