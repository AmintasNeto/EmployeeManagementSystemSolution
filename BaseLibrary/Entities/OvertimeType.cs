
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class OvertimeType : BaseEntity
    {
        // Relationship: Many to One
        [JsonIgnore]
        public List<Overtime>? Overtimes { get; set; }
    }
}
