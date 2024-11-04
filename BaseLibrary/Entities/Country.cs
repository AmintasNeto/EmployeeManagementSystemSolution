namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        // Relationship: One to Many
        public List<City>? Cities { get; set; }
    }
}
