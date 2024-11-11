
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class VacationType : BaseEntity
    {
        // Relationship: Many to One
        [JsonIgnore]
        public List<Vacation>? Vacations { get; set; }
    }
}
