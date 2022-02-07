namespace CountieAPI.Entities
{
    public class Planner
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PlannerProcedure> Procedures { get; set; }

    }
}
