using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
        // Relationship: Many to One
        public City? City { get; set; }
        public int CityId { get; set; }

        // Relationship: One to Many
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
