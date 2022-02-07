namespace CountieAPI.Entities
{
    public class PlannerProcedure
    {
        public int Id { get; set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public int PlannerId { get; set; }
        public Planner Planner { get; set; }
    }
}
