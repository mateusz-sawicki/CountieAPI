namespace CountieAPI.Entities
{
    public class Planner
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProcedureId { get; set; }
        public virtual Procedure Procedure { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

    }
}