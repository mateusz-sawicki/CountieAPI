namespace CountieAPI.Entities
{
    public class Planner
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        
        public virtual Procedure Procedure { get; set; }
    }
}
