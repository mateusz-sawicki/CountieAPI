namespace CountieAPI.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<Procedure> Procedures { get; set; }

    }
}
