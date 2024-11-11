
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SanctionType : BaseEntity
    {
        // Relationship: Many to One
        [JsonIgnore]
        public List<Sanction>? Sanctions { get; set; }
    }
}
