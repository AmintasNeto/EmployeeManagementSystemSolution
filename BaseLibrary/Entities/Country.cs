using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        // Relationship: One to Many
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
