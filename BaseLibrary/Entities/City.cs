namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        // Relationship: Many to One
        public Country? Country { get; set; }
        public int CountryId { get; set; }

        // Relationship: One to Many
        List<Town>? Towns { get; set; }
    }
}
