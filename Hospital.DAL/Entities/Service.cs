namespace Hospital.DAL.Entities
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDesc { get; set; }
    }
}